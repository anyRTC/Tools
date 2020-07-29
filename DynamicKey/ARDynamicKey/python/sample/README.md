- **RtcTokenBuilder.py**: Source code for generating a token for the following SDKs:

> - anyRTC Native SDK v4.0+

> - anyRTC Web SDK v4.0+

- **RtmTokenBuilder.py**: Source code for generating a token for the anyRTC RTM SDK. 
- **AccessToken.py**: Implements all the underlying algorithms for generating a token. Both **RtcTokenBuilder.py** and **RtmTokenBuilder.py** are a wrapper of **AccessToken.py** and have much easier-to-use APIs. We recommend using **RtcTokenBuilder.py** for generating an RTC token or **RtmTokenBuilder.py** for an RTM token.
