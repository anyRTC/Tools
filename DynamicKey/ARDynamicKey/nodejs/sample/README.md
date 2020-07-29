- **RtcTokenBuilder.js**: Source code for generating a token for the following SDKs:

> - anyRTC Native SDK v4.0+

> - anyRTC Web SDK v4.0+

- **RtmTokenBuilder.js**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.js**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.js** and **RtmTokenBuilder.js** are a wrapper of **AccessToken.js** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.js** for generating an RTC token or **RtmTokenBuilder.js** for an RTM token.
