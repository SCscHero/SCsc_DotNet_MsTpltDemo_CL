#添加.net6基础镜像
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#容器工作目录即DotNet程序的目录，需要从DockerFile文件目录指向到程序目录：1)使用./表示是当前目录；2)使用../表示是上一级目录。
WORKDIR ./

#指定项webapi或mvc站点的内部启动端口，默认是80
ENV ASPNETCORE_URLS http://+:33414
 
#暴露docker容器端口
EXPOSE 33414
EXPOSE 443
 
#拷贝发布目录下的所有文件到容器的工作根目录【注意等于说把XXX文件拷到Run的目录】
#COPY . . (这样写也可以)
COPY ./ ./
 
# 如果用System.SqlClient.dll访问数据库，需要加这一句
# RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf
 
#容器入口点
ENTRYPOINT ["dotnet", "SCscCL_WebAPI.dll"]