## anyRTC云端录制上传私有OSS文件存储的参数说明

anyRTC云端录制支持anyRTC私有OSS，当使用私有文件存储时，开始录制时的参数中storageConfig参数修改如下：

bucket：私有OSS上传文件链接（http://host:port/arapi/v1/fdfs/file/uploadOssFile）

vendor：100，100表示自定义私有上传文件系统，不上传云厂商OSS。

fileNamePrefix：（选填）JSONArray 类型，由多个字符串组成的数组，指定录制文件在第三方云存储中的存储位置。举个例子，`fileNamePrefix` = `["directory1","directory2"]`，将在录制文件名前加上前缀 "`directory1/directory2/`"，即 `directory1/directory2/xxx.m3u8`。前缀长度（包括斜杠）不得超过 128 个字符。字符串中不得出现斜杠。以下为支持的字符集范围： - 26 个小写英文字母 a-z - 26 个大写英文字母 A-Z - 10 个数字 0-9



```json
"storageConfig": {
            "bucket": "文件传输接口URL，(http://host:port/arapi/v1/fdfs/file/uploadOssFile)",
            "vendor": 100,
            "fileNamePrefix": ["directory1","directory2"]
        }
```



## 私有OSS存储服务arfdfs配置文件说明

```toml
useConf = "r"
[rConfig]
	# 进程名
  processName = "arfdfs" 
  # 监听Host地址，一般不修改
  host = "0.0.0.0" 
  # 服务端口号（TCP）
  port = 13468
  # 进程pid目录
  pidDir = "/run"
  # 访问文件接口地址前缀（需要nginx配合访问）
  httpOssPrefix = "http://nginx host"
  # nginx可读取的文件目录路径
  ossDir = "/usr/share/nginx/ossdir"
  [rConfig.logger]
    logDir = "/var/log/arfdfs"
    logName = "arfdfs.log"
    logLevel = 4
```



**系统要求：**CentOS 7.6以上，Ubuntu 14.04以上，磁盘能保证业务系统视频文件存储大小

1.  安装nignx服务，nginx配置读取文件，目录路径为配置文件中的ossDir配置的路径
2. 下载arfdfs.tar.gz安装包，解压 tar zxvf arfdfs.tar.gz
3. 安装：进入arfdfs目录，根据配置文件说明配置配置文件，执行：sudo ./arfdfs_install.sh 进行安装，卸载：sudo ./arfdfs_install.sh -u
4. 安装完成后会自行启动服务
5. 启动服务：systemctrl start arfdfs
6. 重启服务：systemctrl restart arfdfs
7. 停止服务：systemctrl stop arfdfs

