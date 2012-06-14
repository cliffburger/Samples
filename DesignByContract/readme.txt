
Executing code analysis without the VS studio addin. 

Sometimes, the UI will not display. Hacking the project files will allow code analysis if the UI does not display.

Read about code contracts here: http://msdn.microsoft.com/en-us/library/dd264808.aspx

Prerequisites: 
	- Install code contracts from http://msdn.microsoft.com/en-us/devlabs/dd491992.aspx
	- The documentation says "Development Tools: Any version of Visual Studio other than the Express edition". 
		However, my Premium edition does not display the expected "Code Contracts" tab in the project properties window.
		You probably need the Ultimate edition to get that VS helper
	- To hack use code contracts by hacking the project files, you probably only need the .NET 4 SDK.

----------------------------------------
Hack your project file (.csproj)

Import the code contract targets. The code contract installer put the code contract file in program files and created the environment variables.
	 <Import Project="$(CodeContractsInstallDir)\MsBuild\v4.0\Microsoft.CodeContracts.targets" Condition=" '$(CodeContractsImported)' == '' " />

These properties make code analysis run. Since code contracts add time to your build, I put them in a new build configuration, "Contracts".
	<CodeContractsRunCodeAnalysis>true</CodeContractsRunCodeAnalysis>
    <CodeContractsEnableRuntimeChecking>true</CodeContractsEnableRuntimeChecking>

Call the target. In this example I put it in AfterBuild
	<Target Name="AfterBuild" DependsOnTargets="CodeContractsPerformCodeAnalysis;CodeContractRewrite"></Target>

-------------- EXAMPLES ---------
The basics of Code Contracts can be seen in BowlingGame. 
Interface contracts can be seen in IFrame.

Inheritence with Contract.Requires ...
	
	Preconditions may be weakened, but not strengthed.
	Postconditions may be strengthened but not weakened.

ContractInvariants
	Called after contsruction and each method.

	[ContractInvariantMethod]
	private void OK()
	{
		Contract.Invariant(balance >0)
	}