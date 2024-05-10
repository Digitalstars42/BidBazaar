import { Component } from '@angular/core';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrl: './form.component.css',
  host: {
    class: 'page-content'
  }
})
export class FormComponent {
  name: string='';
  selectedOption: string = ''; // Додайте властивість selectedOption та ініціалізуйте її
  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      // Ви можете обробити вибраний файл тут, наприклад, відобразити його або відправити на сервер
      console.log('Вибраний файл:', file);
    }
  }
  updateSelectedOption() {
    console.log('Вибрано: ', this.selectedOption);
    // Тут ви можете виконати будь-які додаткові дії з вибраним варіантом
  }
}

