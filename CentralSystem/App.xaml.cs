using CentralSystem.Converters;
using HexInnovation;

namespace CentralSystem;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new MainPage();
        
        math.CustomFunctions.Add(CustomFunctionDefinition.Create<CustomAnd>("CustomAnd"));
    }


}
