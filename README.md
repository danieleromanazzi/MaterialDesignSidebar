# MaterialDesignSidebar
This library is developed in C # and contains a Sidebar control with compressed sections for use in WPF technology. This is an extension for Material Design in the XAML project.

# Introduction
The library contains a two control Sidebar, two level or three level annidations.

You can set an title, description and image on the items.


# Screenshots

Sidebar           |  Three Level Sidebar
:-------------------------:|:-------------------------:
![Sidebar](/Documentation/ExampleSidebarTwoLevel.png) | ![Three Level Sidebar](/Documentation/ExampleSidebarThreeLevel.png)

# See It In Action
Sidebar            |  Three Level Sidebar 
:-------------------------:|:-------------------------:
![Sidebar](/Documentation/SidebarTwoLevel.gif) | ![Three Level Sidebar](/Documentation/SidebarThreeLevel.gif)

#  Getting Started

# Hot to use
- Download the nuget package [MaterialDesignSidebar](https://www.nuget.org/packages/MaterialDesignSidebar) in your Wpf application
- Insert into your app.xaml the sidebar style resource
```xml
<ResourceDictionary Source="pack://application:,,,/MaterialDesignSidebar;component/Themes/MaterialDesignColor.Sidebar.xaml" />
<!-- If you would prefer to use your own colors there is an option for that as well
<ResourceDictionary>
    <Color x:Key="SideBarToggleColor">Black</Color>
    <SolidColorBrush x:Key="SideBarToggleBrush" Color="{DynamicResource SideBarToggleColor}"></SolidColorBrush>
</ResourceDictionary>
-->
<ResourceDictionary Source="pack://application:,,,/MaterialDesignSidebar;component/Themes/MaterialDesignTheme.Sidebar.xaml" />
```
- Declare the namespace into your window or usercontrol
```xml
xmlns:control="clr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignSidebar"
```

## Use Sidebar
- Add control into your Xaml
```xml
<control:Sidebar DataContext="{Binding ThreeLevelSidebar}" ItemsSource="{Binding Items}"
                 ShowItemSeparator="False"
                 control:OpenSidebarOnSelectedItem.Enabled="True"
                 SelectedItem="{Binding SelectedItem}" />
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/TwoLevelSidebarViewModel.cs)

## Use three level Sidebar
- Add control into your Xaml
```xml
<control:ThreeLevelSidebar DataContext="{Binding ThreeLevelSidebar}" ItemsSource="{Binding Items}"
                           ShowItemSeparator="False"
                           control:OpenSidebarOnSelectedItem.Enabled="True"
                           SelectedItem="{Binding SelectedItem}" />
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/ThreeLevelSidebarViewModel.cs)



Special thanks to contributors of project [MaterialDesignInXAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
