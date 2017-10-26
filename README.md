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

```sh
public ObservableCollection<Student> Studenti { get; set; }
```

- Ukázka použití *PropertyChange* u položky kolekce. Pokud chceme, aby se aktualizovalo zobrazení property jednotlivých položkách kolekce, tak musí i typ položky implementovat rohraní INotifyPropertyChange, příkladem je třída [Student](https://github.com/ekral/A3AFW/blob/master/WpfAppStudents/Student.cs).

### WpfAppCounter

- Ukázka použití atributu **CommandParameter** pro předávání parametrů
```sh
<Button Content="Přičti 1" Command="{Binding CommandZmena}" CommandParameter="1" />
```

```sh
private Action<object> _action;

public void Execute(object parameter)
{
    _action?.Invoke(parameter);
}
```

- Ukázka použití atributu **UpdateSourceTrigger** tak aby se hodnota měněného textu předávala hned při editaci textu a ne až pro ztrátě fokusu
```sh
<TextBox Text="{Binding Maximum, UpdateSourceTrigger=PropertyChanged}" />
```
- Ukázka WPF specifické implementace implementace property **CanChange** v [RelayCommandu](https://github.com/ekral/A3AFW/blob/master/WpfAppCounter/MyCommand.cs), díky které můžeme zakázat provedení *Commandu* a u *Buttonu* dojde také automaticky k nastavení property **IsEnabled** na false. 
  
```sh
CommandZmena = new MyCommand(Zmen, MuzeZmenit);

private bool MuzeZmenit()
{
    return Pocitadlo < Maximum;
}
```
- Pokud dochází ke změně návratové hodnoty metody **CanChange** mimo UI, například s pomocí časovače, můžeme informovat tlačítko aby si zavolalo metodu **CanChange** a zjistilo její návratovou hodnotu.
```sh
dispatcherTimer.Tick += (sender, e) => { ++Pocitadlo; CommandZmena.OnCanExecuteChanged(); };
```
- Ukázka nových vlastností jazyka C# 7: *Is-expressions with patterns* a *Out variables* 
```sh
if (param is string retezec)
{
    if (int.TryParse(retezec, out int cislo))
    {
        Pocitadlo += cislo;
    }
}
```
