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
<control:Sidebar DataContext="{Binding TwoLevelSidebar}" ItemsSource="{Binding Items}" 
                 control:SidebarBehavior.ShowSeparator="{Binding IsChecked, ElementName=twolevelseparator}"
                 control:SidebarBehavior.AutoExpand="{Binding IsChecked, ElementName=twolevelOpensidebar}"
                 control:SidebarBehavior.ExpandAll="{Binding IsChecked, ElementName=twolevelExpandAllsidebar}"
                 SelectedItem="{Binding SelectedItem, Mode=TwoWay, NotifyOnSourceUpdated=True, NotifyOnTargetUpdated=True}">
    <control:Sidebar.Resources>
        <ResourceDictionary>

            <Style TargetType="TreeView" BasedOn="{StaticResource MaterialDesignSidebar}"/>
            <Style TargetType="TreeViewItem" BasedOn="{StaticResource MaterialDesignSidebarItem}"/>

            <HierarchicalDataTemplate ItemsSource="{Binding Items}" DataType="{x:Type local:Group}">
                <local:SidebarItem /> <!-- This is a your usercontrol (for group)-->
                <HierarchicalDataTemplate.ItemTemplate>
                    <DataTemplate DataType="{x:Type local:Item}">
                        <local:SidebarItem /> <!-- This is a your usercontrol (for item)-->
                    </DataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>

        </ResourceDictionary>
    </control:Sidebar.Resources>
</control:Sidebar>
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/ViewModels/TwoLevelSidebarViewModel.cs)

## Use three level Sidebar
- Add control into your Xaml
```xml
<control:Sidebar DataContext="{Binding ThreeLevelSidebar}" ItemsSource="{Binding Items}"
                 control:SidebarBehavior.AutoExpand="{Binding IsChecked, ElementName=threelevelOpensidebar}"
                 control:SidebarBehavior.ShowSeparator="{Binding IsChecked, ElementName=threelevelseparator}"
                 control:SidebarBehavior.ExpandAll="{Binding IsChecked, ElementName=threelevelExpandAllsidebar}"
                 SelectedItem="{Binding SelectedItem}">
    <control:Sidebar.Resources>
        <ResourceDictionary>

            <Style TargetType="TreeView" BasedOn="{StaticResource MaterialDesignSidebar}"/>
            <Style TargetType="TreeViewItem" BasedOn="{StaticResource MaterialDesignSidebarMultiLevelItem}"/>

            <HierarchicalDataTemplate ItemsSource="{Binding Items}" DataType="{x:Type local:Group}">
                <local:SidebarItem /> <!-- This is a your usercontrol (for group)-->
                <HierarchicalDataTemplate.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Items}" DataType="{x:Type local:SubGroup}">
                        <local:SidebarItem /> <!-- This is a your usercontrol (for sub-group)-->
                        <HierarchicalDataTemplate.ItemTemplate>
                            <DataTemplate DataType="{x:Type local:Item}">
                                <local:SidebarItem /> <!-- This is a your usercontrol (for item)-->
                            </DataTemplate>
                        </HierarchicalDataTemplate.ItemTemplate>
                    </HierarchicalDataTemplate>
                </HierarchicalDataTemplate.ItemTemplate>
            </HierarchicalDataTemplate>

        </ResourceDictionary>
    </control:Sidebar.Resources>
</control:Sidebar>
```
- Create your viewmodel to populate the hierarchical list, you can [see this example](/MaterialDesignSidebarDemo/ViewModels/ThreeLevelSidebarViewModel.cs)


Special thanks to contributors of project [MaterialDesignInXAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)
