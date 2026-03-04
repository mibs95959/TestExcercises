# Running Tests in Docker

This guide explains how to run the TestExcercise Selenium tests in a Docker container on Linux.

## Prerequisites

- Docker installed
- Docker Compose installed (optional, for easier execution)

## Quick Start

### Option 1: Using Docker

```bash
# Build the Docker image
docker build -t testexercise .

# Run all tests
docker run --rm testexercise

# Run tests with specific tag
docker run --rm testexercise --filter "TestCategory=Demo"

# Run with environment variables for credentials
docker run --rm \
  -e TEST_USERNAME="your-username" \
  -e TEST_PASSWORD="your-password" \
  -e TEST_2FA_SECRET="your-2fa-secret" \
  testexercise
```

### Option 2: Using Docker Compose

1. Create a `.env` file in the root directory:

```env
TEST_USERNAME=your-username
TEST_PASSWORD=your-password
TEST_2FA_SECRET=your-2fa-secret
```

2. Run the tests:

```bash
# Run all tests
docker-compose up

# Run specific tests
docker-compose run --rm testexercise --filter "TestCategory=Demo"

# Run and keep container for debugging
docker-compose run testexercise
```

## Test Results

Test results will be saved to `./TestResults` directory on your host machine.

## Troubleshooting

### Chrome not starting

Ensure Chrome is running in headless mode. The Dockerfile sets this up automatically.

### ChromeDriver version mismatch

The project uses Selenium.WebDriver.ChromeDriver NuGet package which should match the Chrome version in the container.

### Permission issues

If you encounter permission issues with TestResults:

```bash
sudo chown -R $USER:$USER ./TestResults
```

## Running Specific Scenarios

To run specific Reqnroll scenarios by tag:

```bash
# Run scenarios tagged with @Demo
docker run --rm testexercise --filter "Category=Demo"

# Run scenarios tagged with @Todo-DeleteKraken
docker run --rm testexercise --filter "Category=Todo-DeleteKraken"
```

## Development Workflow

1. Make changes to your test code
2. Rebuild the Docker image: `docker build -t testexercise .`
3. Run tests: `docker run --rm testexercise`

## CI/CD Integration

This Dockerfile can be used in CI/CD pipelines:

```yaml
# Example for GitHub Actions
- name: Run Selenium Tests
  run: |
    docker build -t testexercise .
    docker run --rm testexercise
```
