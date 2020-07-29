- **RtcTokenBuilder.php**: Source code for generating a token for the following SDKs:

  - anyRTC Native SDK v4.0+

  - anyRTC Web SDK v4.0+

- **RtmTokenBuilder.php**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.php**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.php** and **RtmTokenBuilder.php** are a wrapper of **AccessToken.php** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.php** for generating an RTC token or **RtmTokenBuilder.php** for an RTM token.
