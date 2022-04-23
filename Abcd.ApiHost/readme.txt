理解模块化
1.新建一个Aspnet core webapi 项目
2.安装Volo.Abp.AspNetCore.Mvc
3.一个Apihost主机 下面有四个应用服务 当一个服务访问量很大的时候 可以直接再建立一个ApiHost 同时把访问量大的服务转移过去  服务直接通过MQ等消息中间件走服务通信 做到了分布式