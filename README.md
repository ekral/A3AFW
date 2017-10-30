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

###Třída Style
Pomocí třídy Style můžeme sdílet nastavení properties (ale také resources a eventů) mezi instancemi konkrétního typu. Objekt typu *Style* se obsahuje kolekci jednoho nebo více objektu typu *Setter*, kdy každý Setter má atribut *Property* a *Value*. Property je název propeperty elementu na který chceme styl aplikovat a Value je jeho hodnota.


