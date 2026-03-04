using OtpNet;

namespace Tools.General_Tools
{
    /// <summary>
    /// This is used to get the 2FA code from the secret key.
    /// </summary>
    public class OTP_Tool
    {

        public static string GetAuthSixDigCode(string secretKey)
        {
            var otpKeyBytes = Base32Encoding.ToBytes(secretKey);
            Totp totp = new Totp(otpKeyBytes);
            return totp.ComputeTotp();
        }

    }
}
