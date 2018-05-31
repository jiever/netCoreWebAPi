FROM microsoft/dotnet:2.0-sdk AS build-env
      
WORKDIR /app

COPY *.sln .

COPY Project.UnitTest /app/Project.UnitTest/
COPY Project.Model /app/Project.Model/
COPY Project.IDAL /app/Project.IDAL/
COPY Project.IBLL /app/Project.IBLL/
COPY Project.DAL /app/Project.DAL/
COPY Project.BLL /app/Project.BLL/
COPY Project.AutoGenerateCode /app/Project.AutoGenerateCode/

COPY Project.WebApi /app/Project.WebApi/

	RUN dotnet restore
	
	
	COPY . /app
	
	RUN dotnet publish -c Release -o out
     
        FROM microsoft/dotnet:2.0-runtime
	WORKDIR /app
	COPY --from=build-env /app/out ./
        
	ENTRYPOINT ["dotnet", "Project.WebApi.dll"]