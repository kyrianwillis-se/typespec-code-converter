Setup
============================================

1. configure the path settingsin appsettings.json
2. build the solution
3. add "post-commit" to the apprpriate directory
	- if husk it being used, add it to the .husky directory (/app/.husky)
	- if using git, place in the .git/hooks directory
4. change post-commit to point to the install location of this application
5. Exclude the generated files from compilation or the repo
	- add the following to all project files:
		<ItemGroup>
		  <Compile Remove="**/Generated/**/*.cs" />
		  <Content Remove="**/Generated/**/*" />
		  <None Remove="**/Generated/**/*" />
		</ItemGroup>
	- add the following to the .gitignore file:
		**/Generated/**