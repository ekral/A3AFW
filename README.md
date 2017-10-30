# A3AFW Application frameworks

### WpfAppStudents 

  - Ukázka zjednodušené verze [RelayCommandu](https://github.com/ekral/A3AFW/blob/master/WpfAppStudents/RelayCommand.cs), která jen volá metodu bez parametru pomocí delegátu.
```c#
private Action _action;  

public void Execute(object parameter)
{
    _action?.Invoke();
}
```
- Ukázka použití kolekce ObservableCollection jako typu property pro bindování, která provádí notifikaci o tom, že došlo k přidání, odebrání nebo změně všech jejich prvků. 

```c#
public ObservableCollection<Student> Studenti { get; set; }
```

- Ukázka použití *PropertyChange* u položky kolekce. Pokud chceme, aby se aktualizovalo zobrazení property jednotlivých položkách kolekce, tak musí i typ položky implementovat rohraní INotifyPropertyChange, příkladem je třída [Student](https://github.com/ekral/A3AFW/blob/master/WpfAppStudents/Student.cs).
### WpfAppCounter

- Ukázka použití atributu **CommandParameter** pro předávání parametrů
```c#
<Button Content="Přičti 1" Command="{Binding CommandZmena}" CommandParameter="1" />

```

```c#
private Action<object> _action;

public void Execute(object parameter)
{
    _action?.Invoke(parameter);
}
```

- Ukázka použití atributu **UpdateSourceTrigger** tak aby se hodnota měněného textu předávala hned při editaci textu a ne až pro ztrátě fokusu
```XAML
<TextBox Text="{Binding Maximum, UpdateSourceTrigger=PropertyChanged}" />
```
- Ukázka WPF specifické implementace implementace property **CanChange** v [RelayCommandu](https://github.com/ekral/A3AFW/blob/master/WpfAppCounter/MyCommand.cs), díky které můžeme zakázat provedení *Commandu* a u *Buttonu* dojde také automaticky k nastavení property **IsEnabled** na false. 
  
```c#
CommandZmena = new MyCommand(Zmen, MuzeZmenit);

private bool MuzeZmenit()
{
    return Pocitadlo < Maximum;
}
```
- Pokud dochází ke změně návratové hodnoty metody **CanChange** mimo UI, například s pomocí časovače, můžeme informovat tlačítko aby si zavolalo metodu **CanChange** a zjistilo její návratovou hodnotu.
```c#
dispatcherTimer.Tick += (sender, e) => { ++Pocitadlo; CommandZmena.OnCanExecuteChanged(); };
```
- Ukázka nových vlastností jazyka C# 7: *Is-expressions with patterns* a *Out variables* 
```c#
if (param is string retezec)
{
    if (int.TryParse(retezec, out int cislo))
    {
        Pocitadlo += cislo;
    }
}
```
## WpfAppStudentTemplates
Studenti s pokročilymi styly. V projektu jsou ukázky následujících témat:
- Style
- Resources
- DataTemplates

### Třída Style
Pomocí třídy [Style](https://docs.microsoft.com/en-us/dotnet/api/system.windows.style?view=netframework-4.7.1) můžeme sdílet nastavení properties (ale také resources a eventů) mezi instancemi konkrétního typu. Objekt typu **Style** má zadaný zázev pomocí atributu **x:Name** a obsahuje kolekci jednoho nebo více objektů typu **Setter**, kdy každý Setter má atribut **Property** a **Value**. Property je název property elementu na který chceme styl aplikovat a Value je jeho hodnota.

Objekt třídy Style se typicky přidáva do kolekce **Resources** kořenového elementu *Window* nebo *Application*. V následujícím příkladu jej ale pro zjednodušení přidáváme do *Resources* elementu *StackPanel*. Konkrétně vytváříme styl s názvem *StyleBlue* který nastaví *Background* a *Foreground* třídy *TextBlock*. Tento styl potom aplikujeme na dva elementy **TextBlock** pomocí atributu **Style**.
```XAML
<StackPanel>
    <StackPanel.Resources>
        <Style x:Key="StyleBlue" >
            <Setter Property="TextBlock.Background" Value="LightBlue" />
            <Setter Property="TextBlock.Foreground" Value="Black" />
        </Style>
    </StackPanel.Resources>
    <TextBlock Style="{StaticResource ResourceKey=StyleBlue}" Text="Ahoj" />
    <TextBlock Style="{StaticResource ResourceKey=StyleBlue}" Text="Jak se máš" />
</StackPanel>
```
Pomocí atributu **TargetType** muzeme zapis elementu *TextBlock* zkrátit a místo ```XAML Property="TextBlock.Background"``` napsat jen ```XAML Property="Background"```.
```XAML
<StackPanel>
    <StackPanel.Resources>
        <Style TargetType="TextBlock" x:Key="StyleBlue" >
            <Setter Property="Background" Value="LightBlue" />
            <Setter Property="Foreground" Value="Black" />
        </Style>
    </StackPanel.Resources>
    <TextBlock Style="{StaticResource ResourceKey=StyleBlue}" Text="Ahoj" />
    <TextBlock Style="{StaticResource ResourceKey=StyleBlue}" Text="Jak se máš" />
</StackPanel>
```
### XAML Resources
Každý element má property [Resources](https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/xaml-resources#styles-datatemplates-and-implicit-keys), která obsahuje obsahuje objekty, které se pak používají na různých místech aplikace. Typickým příkladem jsou objekty typu *Style*, *Brush* a *DataTemplate*. Objekty se typicky přidávájí do *Resources* elementu *Application* pokud je chceme používat v celé aplikaci, nebo do *Resources* elementu *Window*, pokud je chceme používat pouze v jednom okně aplikace. Každý objekt v Resources musí mít atribut ```XAML x:Key```.
K přístupu k objektům v *Resources* potom používáme Markup Extension **StaticResource** nebo **DynamicResource**. *StaticResource* používáme, pokud předpokládáme, že se hodnota objektu za běhu programu nemění a stačí ho načíst jen jednou na začátku programu, například *Style* zůstává pořád stejný. *DynamicResource* potom používáme, když očekáváme, že se objekt bude v průběhu programu měnit nebo hodnota není známá před spuštění programu (například systémové barvy operačního systému).
V následujícím příkladě přidáme do *Resources* elementu *Window* objekt typu *SolidColorBrush*, který použijeme pro výplň objektu typu *Ellipse* a objekt typu *Style*, použijme na objekt typu *TextBlock*. 

```XAML
<Window x:Class="WpfAppStudentTemplates.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Window.Resources>
        <SolidColorBrush x:Key="ModryStetec" Color="Blue" />
        <Style TargetType="TextBlock" x:Key="StyleZlutePozadi" >
            <Setter Property="Background" Value="LightYellow" />
        </Style>
    </Window.Resources>
    <StackPanel>
        <TextBlock Style="{StaticResource ResourceKey=StyleZlutePozadi}" Text="Ahoj" />
        <Ellipse Width="30" Height="30" Fill="{StaticResource ModryStetec}"/>
    </StackPanel>
</Window>
```
Todo:
- DataTemplate
- Conditional DataTemplate
