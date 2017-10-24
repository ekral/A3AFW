 # A3AFW Application frameworks

### WpfAppCounter

  - Ukázka použití atributu **UpdateSourceTrigger** tak aby se hodnota změna textu předávala hned při editaci textu a ne až pro ztrátě fokusu
```sh
<TextBox Text="{Binding Maximum, UpdateSourceTrigger=PropertyChanged}" />
```
  - Ukázka implementace property **CanChange** v [RelayCommandu](https://github.com/ekral/A3AFW/blob/master/WpfAppCounter/MyCommand.cs)
  
  
### WpfAppStudents 

  - Import a HTML file and watch it magically convert to Markdown
  - Drag and drop images (requires your Dropbox account be linked)
