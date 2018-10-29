FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 1842
EXPOSE 44354

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Products/Products.csproj", "Products/"]
RUN dotnet restore "Products/Products.csproj"
COPY . .
WORKDIR "/src/Products"
RUN dotnet build "Products.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Products.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Products.dll"]