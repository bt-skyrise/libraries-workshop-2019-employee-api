#---------------------------------------------
# Build api
#---------------------------------------------
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore

# Copy everything else and build
COPY . ./

# Publish
RUN dotnet publish -c Release -o /app/out

#---------------------------------------------
# Create final runtime image
#---------------------------------------------
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS final
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Workshop2019.EmployeeApi.dll"]