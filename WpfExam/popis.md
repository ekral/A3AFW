# Popis vzorového úkolu

Příklad obsahuje základy toho co byste měli znát abyste uspěli u testu.

Základní pojmy:

- **View** - typicky jedno okno aplikace, tedy to co vidí uživatel
- **ViewModel** - je třída obsahující data pro zobrazení, konkrétně property, které chceme zobrazovat ve View. Například *MainViewModel*. Mmodel jsou obecně data v paměti.
- **Bindování** - mechanismus pomocí kterého spolu komunikují View a View model a přitom na sebe nemají přímou referenci, což umožňuje nezávislý vývoj a testování.
- **PropertyChange** - event v rozhraní *INotifyPropertyChanged* pomocí kterého ViewModel informuje control ve View, například TextBox, že došlo ke změně property ve ViewModelu a View ji má znovu načíst a zobrazit.
- **Command** - pomocí commandů může View volat metody ViewModelu a opět na sebe nemusí mít referenci. Commnand je potom třída implementující rozhraní *ICommand*. Ve ViewModelu potom vytváříme property typu Commmand a předáváme jí delegáta na metodu ve ViewModelu, kterou chceme zavolat. Ve View potom například Button na tuto property Command binduje.

Základní struktura:

- Vytvoření instance *MainViewModel*u pro *MainView* v souboru *App.xaml.cs* a jeho přiřazení property *DataContext*. Nezapomeňte smazat atribut *StartupUri* v souboru *App.xaml*. Instanci modelu bychom mohli vytvořit i v XAMLu, ale nemohli bychom potom předávat žádné parametry v konstruktoru,používat Dependency Injection a techniku Inversion of Control. V tomto jednoduchém příkladu bychom ale mohli použít oba způsoby.

    ```c#
    ViewModel.MainViewModel data = new ViewModel.MainViewModel();
    View.MainView window = new View.MainView() { DataContext = data };
    ```
- Bindovaní v souboru *MainView.xaml*. Pomocí markup extension Binding říkáme, že má *TextBox* zobrazit a měnit hodnotu property *Rezetec* objektu v property *DataContext* (připomínám, že ta má referenci na model, což jsme udělali v předchozím kroku). Zápis *UpdateSourceTrigger=PropertyChanged* znamená, že *TextBox* bude měnit hodnotu property *Retezec* pokaždé hned, jak se změní property *Text*.

     ```XAML
     <TextBox Text="{Binding Retezec, UpdateSourceTrigger=PropertyChanged}" />
    ```

- Použití eventu *PropertyChanged* rozhraní *INotifyPropertyChange*. Pomocí tohoto eventu říkáme například *TextBoxu*, že došlo ke změně hodnoty property *Retezec* a *TextBox* má tuto hodnotu znovu načíst a zobrazit.
  - Implementací rozhraní *INotifyPropertyChange* je třída *ViewModelBase*, tak abychom nemuseli implementaci znovu vytvářet pro všechny další ViewModely, ale v takto jednoduchém příkladu to samozřejmě nebylo nutné. Díky použití atributu *[CallerMemberName]* u parametru *name* nemusíme volat metodu s názvem property, viz příklad níže.

    ```c#
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    ```
  - Event *PropertyChange* vyvoláme voláním metody *OnPropertyChange* pokaždé, když chceme informovat *MainView* o tom, že ve *MainViewModelu* došlo ke změně, což děláme většinou ve setteru property. Protože parametr *name* metody *OnPropertyChange* má atribut *[CallerMemberName]*, nemusíme zadávat název property a automaticky se doplní název property *Pocet*. Také jsme ale mohli použít zápis *OnPropertyChanged("Pocet")* nebo *OnPropertyChanged(nameof(Pocet))*.

    ```c#
    public int Pocet
    {
        get { return _pocet; }
        set { _pocet = value; OnPropertyChanged(); }
    }
    ```

- Nejprve musíme vytvořit třídu *RelayCommand* jako implementaci rozhraní *ICommand*. Poté vytvoříme property typu *RelayCommand* v *MainViewModelu* a v *MainView* potom bindujeme na tuto property.
  - Definice třídy *RelayCommand* jako implementace rozhraní *ICommand*. Ve třídě je delegát *_action*, pomocí kterého budeme volat metodu ve *MainViewModelu*.
    ```c#
    public class RelayCommand : ICommand
    {
        private Action _action;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
    ```
  - Definice Property a názvem *CommandReset* typu *RelayCommand* ve třídě *MainViewModel* a vytvoření její instance v konstruktoru. *Reset* je název metody na kterou předáváme referenci a ve které nulujeme počet znaků a nastavíme řetězce na prázdné.
    ```c#
    public RelayCommand CommandReset { get; set; }
    ```
    ```c#
    CommandReset = new RelayCommand(Reset);
    ```
    ```c#
    private void Reset()
    {
        Retezec = string.Empty;
        Znak = string.Empty;
        Pocet = 0;
    }
    ```
  - Bindování property Command na tlačítku v *MainView* na property *CommandReset* ve *ViewModelu*. Pokud se stiskne tlačítko Reset, tak se zavolá metoda Execute v třídě *RelayCommand* a v té se pomocí delegáta *_action* zavolá metoda *Reset* v *MainViewModelu*.
    ```XAML
    <Button Content="Reset" Command="{Binding CommandReset}"/>
    ```
