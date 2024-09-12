# RayGUI_cs

RayGUI_cs is a complementary GUI library for the C# [wrapper](https://github.com/ChrisDill/Raylib-cs) of the graphic library [Raylib](https://www.raylib.com/).
It was intially created for the [Uniray](https://git.s2.rpn.ch/ComtesseE1/uniray) Game Engine, but should work just fine in any other projects. 
You will find below a guid to build & and use the library for your own Raylib projects. 

## Build

- [ ] [Install](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) the **Net6.0 Framework** (minimum required) if you don't have it already.
- [ ] Run the following command in the project directory:

```
dotnet build
```

You now have a .dll file that was generated in the bin folder of the project.

## Use

To use the library, simply copy the .dll file in your C# project. Set a dependence to the file using the Visual Studio GUI or insert these lines in your .csproj file:

```
<ItemGroup>
    <Reference Include="RayGUI_cs">
        <HintPath>**RELATIVE_PATH_TO_LIBRARY**\RayGUI_cs.dll</HintPath>
    </Reference>
</ItemGroup>
```

You can now use the library's functions and classes inside of your Raylib projet to enjoy a good GUI.
Though if you encounter any problems using the .dll, go check out Microsoft's [documentation](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager?view=vs-2022)

## Contact

If you have any request, consider contacting me at Evan.Comtesse@rpn.ch