FROM mcr.microsoft.com/dotnet/core/sdk:2.1
MAINTAINER Harsh Manvar "harsh.manvar111@gmail.com"
RUN mkdir /src
WORKDIR /src
ADD . /src
RUN dotnet restore
RUN ["dotnet", "build", "--configuration", "release"]

ENTRYPOINT [ "dotnet", "run", "--no-launch-profile" ]