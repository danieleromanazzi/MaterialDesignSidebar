# MaterialDesignSidebar
This library is developed in C # and contains a Sidebar control with compressed sections for use in WPF technology. This is an extension for Material Design in the XAML project.

[![Maintainability](https://api.codeclimate.com/v1/badges/6962fb7e31caa20648c1/maintainability)](https://codeclimate.com/github/danieleromanazzi/MaterialDesignSidebar/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/6962fb7e31caa20648c1/test_coverage)](https://codeclimate.com/github/danieleromanazzi/MaterialDesignSidebar/test_coverage)

# Introduction
The library contains a two control Sidebar, two level or three level annidations.

You can set an title, description and image on the items.


# Screenshots

Sidebar           |  Three Level Sidebar
:-------------------------:|:-------------------------:
![Sidebar](/Images/ExampleSidebarTwoLevel.png) | ![Three Level Sidebar](/Images/ExampleSidebarThreeLevel.png)

# See It In Action
Sidebar            |  Three Level Sidebar 
:-------------------------:|:-------------------------:
![Sidebar](/Images/SidebarTwoLevel.gif) | ![Three Level Sidebar](/Images/SidebarThreeLevel.gif)

#  Getting Started

# How to use
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
<control:Sidebar DataContext="{Binding SimpleSidebarViewModel}" ItemsSource="{Binding Items}" 
                 control:SidebarBehavior.ShowSeparator="{Binding DataContext.ShowSeparator, RelativeSource={RelativeSource AncestorType=Window}}"
                 control:SidebarBehavior.AutoExpandOnSelect="{Binding DataContext.AutoExpandOnSelect, RelativeSource={RelativeSource AncestorType=Window}}"
                 control:SidebarBehavior.ExpandAll="{Binding DataContext.ExpandAll, RelativeSource={RelativeSource AncestorType=Window}}"
                 SelectedItem="{Binding SelectedItem, Mode=TwoWay, NotifyOnSourceUpdated=True, NotifyOnTargetUpdated=True}">
    <control:Sidebar.Resources>
        <ResourceDictionary>
            <Style TargetType="TreeViewItem" BasedOn="{StaticResource MaterialDesignSidebarItem}"/>
        </ResourceDictionary>
    </control:Sidebar.Resources>
    <control:Sidebar.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding Items}">
            <local:SidebarItem />
            <HierarchicalDataTemplate.ItemTemplate>
                <DataTemplate>
                    <local:SidebarItem />
                </DataTemplate>
            </HierarchicalDataTemplate.ItemTemplate>
        </HierarchicalDataTemplate>
    </control:Sidebar.ItemTemplate>
</control:Sidebar>
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/ViewModels/TwoLevelSidebarViewModel.cs)

## Use three level Sidebar
- Add control into your Xaml
```xml
<control:Sidebar DataContext="{Binding CompositeSidebarViewModel}" ItemsSource="{Binding Items}"
                 control:SidebarBehavior.ShowSeparator="{Binding DataContext.ShowSeparator, RelativeSource={RelativeSource AncestorType=Window}}"
                 control:SidebarBehavior.AutoExpandOnSelect="{Binding DataContext.AutoExpandOnSelect, RelativeSource={RelativeSource AncestorType=Window}}"
                 control:SidebarBehavior.ExpandAll="{Binding DataContext.ExpandAll, RelativeSource={RelativeSource AncestorType=Window}}"
                 SelectedItem="{Binding SelectedItem}">
    <control:Sidebar.Resources>
        <ResourceDictionary>
            <Style TargetType="TreeViewItem" BasedOn="{StaticResource MaterialDesignSidebarIndentItem}"/>
        </ResourceDictionary>
    </control:Sidebar.Resources>
    <control:Sidebar.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding Items}">
            <local:SidebarItem />
            <HierarchicalDataTemplate.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Items}">
                    <local:SidebarItem />
                    <HierarchicalDataTemplate.ItemTemplate>
                        <DataTemplate>
                            <local:SidebarItem />
                        </DataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
            </HierarchicalDataTemplate.ItemTemplate>
        </HierarchicalDataTemplate>
    </control:Sidebar.ItemTemplate>
</control:Sidebar>
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/ViewModels/ThreeLevelSidebarViewModel.cs)


Special thanks to contributors of project [MaterialDesignInXAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
