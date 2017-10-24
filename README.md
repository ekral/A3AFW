# A3AFW Application frameworks

### WpfAppCounter

- Ukázka použitím atributu **CommandParamter** pro předávání parametrů
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
- Pokud dochází ke změně hodnoty mimo UI, například s pomocí časovače, můžeme vynutit aby si tlačítko načetlo hodnotu **CanChange**.
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
### WpfAppStudents 

  - Ukázka zjednodušené verze [RelayCommandu](https://github.com/ekral/A3AFW/blob/master/WpfAppStudents/RelayCommand.cs), která jen volá metodu bez parametru pomocí delegátu.
  ```sh
public void Execute(object parameter)
{
    _action?.Invoke();
}
```
  - Drag and drop images (requires your Dropbox account be linked)
