# ARDynamicKey

This page describes the authentication mechanism used by the anyRTC SDK, as well as providing the related code for generating AccessToken (v2.1.0) or Dynamic Key (v2.0.2 or earlier).

## AccessToken

AccessToken is more powerful than the legacy Dynamic Key. It encapsulates several privileges in one token to cover various services provided by anyRTC.

AccessToken is available as of SDK 2.1.0.

Sample usage,

```c++
AccessToken a(appID, appCertificate, channelName, uid);
a.AddPrivilege(AccessToken::kJoinChannel);
a.AddPrivilege(AccessToken::kPublishAudioStream);
std::string token = a.Build();
```
Sample Code for generating AccessToken are available on the following platforms:

 + C++
 + Go
 + Java
 + Node.js
 + Python
 + PHP
 + C#

### **YOUR IMPLEMENTATIONS ARE VERY WELCOME.**

If you have implemented our algorithm in other languages, kindly file a pull request with us. We are delighted to merge any of the implementations that are correct and have test cases. Many thanks.


## Dynamic Key

The Dynamic Key is used by anyRTC SDKs of versions earlier than 2.1.

 + To join a media channel, use generateMediaChannelKey.
 + For recording services, use generateRecordingKey.

Following are samples for C++, Go, Java, Nodejs, PHP and Python.

### SDK and Dynamic Key Compatibility

If you are using the anyRTC SDK of a version earlier than 2.1 and looking at implementing the function of publishing with a permission key, anyRTC recommends that you upgrade to DynamicKey5.

#### To verify user permission in channel:
| Dynamic Key Version | UID | SDK Version  |
|---|---|---|
| DynamicKey5  | specify the permission | 1.7.0 or later  |


#### To verify the User ID:

| Dynamic Key Version | UID | SDK Version  |
|---|---|---|
| DynamicKey5  | specify uid of user | 1.3.0 or later  |
| DynamicKey4  | specify uid of user | 1.3.0 or later  |
| DynamicKey3  | specify uid of user  | 1.2.3 or later  |
| DynamicKey  |  NA |  NA |

#### If you do not need to verify the User ID:

| Dynamic Key Version | UID | SDK Version  |
|---|---|---|
| DynamicKey5  | 0 | All |
| DynamicKey4  | 0 | All |
| DynamicKey3  | 0 | All |
| DynamicKey  | All | All |



### C++
```c
/**
 * build with command:
 * g++ main.cpp  -lcrypto -std=c++0x
 */
#include "../src/DynamicKey5.h"
#include <iostream>
#include <cstdint>
using namespace ar::tools;

int main(int argc, char const *argv[]) {
  ::srand(::time(NULL));

  auto appID  = "970ca35de60c44645bbae8a215061b33";
  auto  appCertificate   = "5cfd2fd1755d40ecb72977518be15d3b";
  auto channelName= "my channel name for recording";
  auto  unixTs = ::time(NULL);
  int randomInt = (::rand()%256 << 24) + (::rand()%256 << 16) + (::rand()%256 << 8) + (::rand()%256);
  uint32_t uid = 2882341273u;
  auto  expiredTs = 0;

  std::cout << std::endl;
  std::cout << DynamicKey5::generateMediaChannelKey(appID, appCertificate, channelName, unixTs, randomInt, uid, expiredTs) << std::endl;
  return 0;
}

```

### Go
```go
package main

import (
    "../src/DynamicKey5"
    "fmt"
)

func main() {
    appID:="970ca35de60c44645bbae8a215061b33"
    appCertificate:="5cfd2fd1755d40ecb72977518be15d3b"
    channelName := "7d72365eb983485397e3e3f9d460bdda"
    unixTs:=uint32(1446455472)
    uid:=uint32(2882341273)
    randomInt:=uint32(58964981)
    expiredTs:=uint32(1446455471)

    var mediaChannelKey,channelError = DynamicKey5.GenerateMediaChannelKey(appID, appCertificate, channelName, unixTs, randomInt, uid, expiredTs)
    if channelError == nil {
        fmt.Println(mediaChannelKey)
    }

}
```

### Java
```java
package io.ar.media.sample;

import io.ar.media.DynamicKey5;

import java.util.Date;
import java.util.Random;

public class DynamicKey5Sample {
    static String appID = "970ca35de60c44645bbae8a215061b33";
    static String appCertificate = "5cfd2fd1755d40ecb72977518be15d3b";
    static String channel = "7d72365eb983485397e3e3f9d460bdda";
    static int ts = (int)(new Date().getTime()/1000);
    static int r = new Random().nextInt();
    static long uid = 2882341273L;
    static int expiredTs = 0;

    public static void main(String[] args) throws Exception {
        System.out.println(DynamicKey5.generateMediaChannelKey(appID, appCertificate, channel, ts, r, uid, expiredTs));
    }
}
```

### Node.js
```javascript
var DynamicKey5 = require('../src/DynamicKey5');
var appID  = "970ca35de60c44645bbae8a215061b33";
var appCertificate     = "5cfd2fd1755d40ecb72977518be15d3b";
var channel = "my channel name";
var ts = Math.floor(new Date() / 1000);
var r = Math.floor(Math.random() * 0xFFFFFFFF);
var uid = 2882341273;
var expiredTs = 0;

console.log("5 channel key: " + DynamicKey5.generateMediaChannelKey(appID, appCertificate, channel, ts, r, uid, expiredTs));
```

### PHP
```php
<?php
include "../src/DynamicKey5.php";

$appID = '970ca35de60c44645bbae8a215061b33';
$appCertificate = '5cfd2fd1755d40ecb72977518be15d3b';
$channelName = "7d72365eb983485397e3e3f9d460bdda";
$ts = 1446455472;
$randomInt = 58964981;
$uid = 2882341273;
$expiredTs = 1446455471;

echo generateMediaChannelKey($appID, $appCertificate, $channelName, $ts, $randomInt, $uid, $expiredTs) . "\n";
?>

```

### Python
```python
import sys
import os
import time
from random import randint

sys.path.append(os.path.join(os.path.dirname(__file__), '../src'))
from DynamicKey5 import *

appID   = "970ca35de60c44645bbae8a215061b33"
appCertificate     = "5cfd2fd1755d40ecb72977518be15d3b"
channelname = "7d72365eb983485397e3e3f9d460bdda"
unixts = int(time.time());
uid = 2882341273
randomint = -2147483647
expiredts = 0

print "%.8x" % (randomint & 0xFFFFFFFF)

if __name__ == "__main__":
    print generateMediaChannelKey(appID, appCertificate, channelname, unixts, randomint, uid, expiredts)

```


### C#
```c#
using AnyRtcTools;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var appID = "970CA35de60c44645bbae8a215061b33";
            var appCertificate = "5CFd2fd1755d40ecb72977518be15d3b";
            var channelName = "7d72365eb983485397e3e3f9d460bdda";
            var userAccount = "2882341273";

            var expireTimeInSeconds = 3600;
            var currentTimestamp = DateTime.UtcNow.Subtract(
                new DateTime(1970, 1, 1)).TotalSeconds;
            var privilegeExpiredTs = (int)currentTimestamp 
                + expireTimeInSeconds;

            var token = new AccessToken(appID, 
                appCertificate, channelName, userAccount);
            token.AddPrivilege(AccessToken.kJoinChannel, 
                privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishVideoStream, 
            //    privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishAudioStream, 
            //    privilegeExpiredTs);
            //token.AddPrivilege(AccessToken.kPublishDataStream,    
            //    privilegeExpiredTs);

            Console.WriteLine(token.Build());

            Console.ReadLine();
        }
    }
}

```

