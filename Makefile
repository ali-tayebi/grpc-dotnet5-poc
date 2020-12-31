SHELL=/bin/bash
-include .env

.DEFAULT_GOAL := help
.PHONY: run-server run-client build-server build-client dotnet-run dotnet-build dotnet-clean help

# Make is verbose in Linux. Make it silent. 
MAKEFLAGS += --silent

## run-server: run ProductInfo service
run-server:
	@$(MAKE) dotnet-run PROJ="src/ProductInfo/ProductInfo.csproj"

## run-client: run Consumer app
run-client:	
	@$(MAKE) dotnet-run PROJ="src/Consumer/Consumer.csproj"

## run-server: clean and build ProductInfo service
build-server:
	@$(MAKE) dotnet-clean PROJ="src/ProductInfo/ProductInfo.csproj"
	@$(MAKE) dotnet-build PROJ="src/ProductInfo/ProductInfo.csproj"

## run-client: run Cunsumer app
build-client:
	@$(MAKE) dotnet-clean PROJ="src/Consumer/Consumer.csproj"
	@$(MAKE) dotnet-build PROJ="src/Consumer/Consumer.csproj"

dotnet-run:
	@echo "  >  Running '$(PROJ)'..."
	@dotnet run -p $(PROJ)

dotnet-build:
	@echo "  >  Building '$(PROJ)'..."
	@dotnet build $(PROJ)

dotnet-clean: 
	@echo "  >  Cleaning '$(PROJ)'..."
	@dotnet clean $(PROJ) -v quiet

## help: Shows available commands
help: Makefile
	@echo
	@echo " Choose a command from following to run:"
	@echo
	@sed -n 's/^##//p' $< | column -t -s ':' |  sed -e 's/^/ /'
	@echo