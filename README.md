# MaterialDesignSidebar
This library is developed in C # and contains a Sidebar control with compressed sections for use in WPF technology. This is an extension for Material Design in the XAML project.

# Introduction
The control Sidebar can work in two modality, two level or three level annidations.

You can set an title, description and image on the items.


# Screenshots

Sidebar Two Level            |  Sidebar Three Level
:-------------------------:|:-------------------------:
![Sidebar Two Level](/Documentation/ExampleSidebarTwoLevel.png) | ![Sidebar Three Level](/Documentation/ExampleSidebarThreeLevel.png)

# See It In Action
Sidebar Two Level            |  Sidebar Three Level
:-------------------------:|:-------------------------:
![Sidebar Two Level](/Documentation/SidebarTwoLevel.gif) | ![Sidebar Three Level](/Documentation/SidebarThreeLevel.gif)

#  Getting Started

# Hot to use
- Download the nuget package in your Wpf application
- Insert into your app.xaml the sidebar style resource
```xml
<ResourceDictionary Source="pack://application:,,,/ExpandableSidebar;component/Themes/SideBar.xaml" />
```
- Declare the namespace into your window or usercontrol
```xml
xmlns:control="clr-namespace:MaterialDesignThemes.Wpf;assembly=ExpandableSidebar"
```
- Add control into your Xaml
```xml
                <control:Sidebar DataContext="{Binding ThreeLevelSidebar}" ItemsSource="{Binding Items}"
                                 ShowItemSeparator="False"
                                 SelectedItem="{Binding SelectedItem}" />
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/ExpandableSidebarDemo/TwoLevelSidebarViewModel.cs)





Special thanks to contributors of project [MaterialDesignInXAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
