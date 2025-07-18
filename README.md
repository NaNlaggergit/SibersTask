# Инструкция по запуску проекта

1. **Клонируем репозиторий**

2. **Настройка базы данных**
   - В проекте `Presentation` открываем файл `appsettings.json`
   - Подключаем ваш MSSQL (я использовал SQLEXPRESS)

3. **Создание базы данных**
   - Открываем Package Manager Console
   - Выполняем команду в проекте `Presentation`:
     ```powershell
     Update-Database
     ```
   ![Команда Update-Database](https://github.com/user-attachments/assets/78a6cab5-a577-4d8f-ae16-e81ac6950162)

4. **Настройка запуска проектов**
   - Кликаем правой кнопкой на Solution
   - Выбираем "Configure Startup Projects"
   - Настраиваем как на скриншоте (обязательно выбираем HTTPS)
   
   ![Настройка Startup Projects](https://github.com/user-attachments/assets/e478e1d1-a0a9-4ca0-bd6f-b5d8c8a3f80d)

5. **Запуск проекта**
   - После запуска откроется две веб-странички
   - Переходим к страничке с Blazor

6. **Работа с приложением**
   - Слева можно выбрать страницы для создания или просмотра записей
   
   ![Главное меню](https://github.com/user-attachments/assets/2e2f59ed-aa3a-489d-a196-84e12e16d056)

7. **Создание работников**
   ![Форма создания работника](https://github.com/user-attachments/assets/42fd7b2a-b81a-479d-9b94-850ce2270eec)

8. **Управление работниками**
   - Созданные работники появятся в разделе Employees
   - Здесь можно удалять или редактировать записи
   
   ![Список работников](https://github.com/user-attachments/assets/ecb7bb6b-ae3f-49a7-b615-a590b9f7c8e1)

9. **Управление проектами**
   - Аналогичный функционал работает с проектами
