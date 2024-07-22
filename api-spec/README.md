# API Definition
This is a definition for the api contained in the parent folder. 

## Setting Up A New TypeSpec Application 
These steps assume the target folder is empty. Commands in steps 2,3, and 5 can all be safely run if the folder is not empty. Step 4 is only needed if there is no tspconfig.yaml file present.

1. Go to the folder where the typespec app will reside

2. Initializes a new Node.js project in the current directory, creating a package.json file with default settings.
	npm init -y  
		
3. Installs the TypeSpec compiler and the necessary packages as development dependencies in your project.
	npm install @typespec/compiler @typespec/http @typespec/rest @typespec/openapi3 --save-dev

4. Add tspconfig.yaml (if it does not exist) with the following two lines:
	emitters:
		"@typespec/openapi3": {}
		
5. To compile to openapi3
	npx tsp compile src/main.tsp --emit @typespec/openapi3