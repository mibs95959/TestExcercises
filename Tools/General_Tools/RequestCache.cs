using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace Tools.General_Tools
{
    public class RequestCache
    {
        private IWebDriver Driver { get; }

        public RequestCache(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Private method for printing. Will be useful when implementing this to verify that the JS is working as expected.
        /// </summary>
        private void DebugPrint(bool debugging, string message)
        {
            if (debugging)
            {
                System.Console.WriteLine(message);
            }
        }
        /// <summary>
        /// Prints the operation name table which includes the amount of times each operation has been executed. Requires SetupGraphQLInterceptor to be run first.
        /// Used to verify that we've only called each operation once after test execution.
        /// </summary>
        public void PrintOperationNameTable()
        {
            System.Console.WriteLine("Getting operationCountTable");
            string getCountTableScript = "return window.getOperationCountTable();";
            var executor = (IJavaScriptExecutor)Driver;
            string result = (string)executor.ExecuteScript(getCountTableScript);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Intercept all requests for a given URL pattern and inject a header with a given name and value.
        /// Useful for adding e.g Authorization headers to requests.
        /// </summary>
        /// <param name="urlPattern"></param>
        /// <param name="headerName">Authorization header name (e.g x-api-key, Authorization)</param>
        /// <param name="headerValue">Authorization header value</param>
        /// <param name="debugging">Optional. Enable to print debug info</param>
        /// <param name="additionalJavaScript">If additional JS is required, e.g setting localStorage properties on authorization</param>

        public void SetupHttpRequestInterceptor(string urlPattern, string headerName, string headerValue, bool debugging = false, string additionalJavaScript = "")
        {
            //DebugPrint(debugging, "Waiting for page to load before injecting HTTP request interceptor script...");
            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");

            DebugPrint(debugging, "Injecting HTTP request interceptor script...");
            string script = $@"
                var originalFetch = window.fetch;

                {additionalJavaScript}

                window.fetch = function(input, init) {{
                    var method = (init && init.method) || 'GET';
                    var url = (typeof input === 'string') ? input : input.url;
                    console.log('Fetch request intercepted:', method, url);


                    init = init || {{}};
                    init.headers = init.headers || {{}};
                    init.headers['{headerName}'] = '{headerValue}';

                    console.log('Header injected:', '{headerName}: {headerValue}');

                    return originalFetch(input, init);
                }};
            ";

            var executor = (IJavaScriptExecutor)Driver;
            var result = (string)executor.ExecuteScript(script);
            DebugPrint(debugging, result);
        }

        /// <summary>
        /// Intercept and cache all GraphQL requests, debugging will print
        /// </summary>
        public void SetupGraphQLInterceptor(bool debugging = false)
        {
            DebugPrint(debugging, "Waiting for page to load before injecting GraphQL interceptor script...");
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete");

            DebugPrint(debugging, "Injecting GraphQL interceptor script...");
            string script = @"
                    var cache = {};
                    var operationCount = {};
                    var originalFetch = window.fetch;

                    window.fetch = function(input, init) {
                        var method = (init && init.method) || 'GET';
                        var url = (typeof input === 'string') ? input : input.url;
                        console.log('Fetch request intercepted:', method, url);

                        if (method.toUpperCase() === 'POST' && url.includes('/graphql')) {
                            var body = (init && init.body) || '{}';
                            try {
                                var requestData = JSON.parse(body);
                                var operationName = requestData.operationName;
                                console.log('Operation Name:', operationName);

                                if (cache[operationName]) {
                                    console.log('Serving from cache:', operationName);
                                    return Promise.resolve(new Response(JSON.stringify(cache[operationName]), {
                                        status: 200,
                                        headers: {
                                            'Content-type': 'application/json'
                                        }
                                    }));
                                } else {
                                    console.log('Making network request for:', operationName);
                                    
                                    // Increment the counter for this operation
                                    operationCount[operationName] = (operationCount[operationName] || 0) + 1;

                                    return originalFetch(input, init).then(function(response) {
                                        if (response.ok) {
                                            return response.clone().json().then(function(data) {
                                                cache[operationName] = data;
                                                console.log('Response cached for operation:', operationName);
                                                return response;
                                            });
                                        }
                                        return response;
                                    }).catch(function(error) {
                                        if (error.name === 'AbortError') {
                                            // Request was aborted by clicking away from the page before it completed
                                            console.log('Request aborted for operation:', operationName);
                                        } else {
                                            console.error('Fetch error:', error);
                                        }
                                        throw error;
                                    });
                                }
                            } catch (e) {
                                console.error('Error processing request body:', e);
                            }
                        } else {
                            return originalFetch(input, init);
                        }
                    };

                    window.getOperationCountTable = function() {
                        var table = 'Operation Name\t\tCount\n';
                        table += '----------------------------------\n';
                        for (var operationName in operationCount) {
                            table += operationName + '\t\t' + operationCount[operationName] + '\n';
                        }
                        return table;
                    };
                ";
            var executor = (IJavaScriptExecutor)Driver;
            var result = (string)executor.ExecuteScript(script);
            DebugPrint(debugging, result);
        }
    }
}