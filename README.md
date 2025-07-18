1. Клонируем репозиторий.
2. В проекте Presentation открываем файл appsettings.json и подключаем ваш MSSQL(я использовал SQLEXPRESS).
3. Создаём базу данных c помощью команды Update-Database в Package Manager Console в проекте Presentation.
4. <img width="1531" height="224" alt="image" src="https://github.com/user-attachments/assets/78a6cab5-a577-4d8f-ae16-e81ac6950162" />
5. Кликаем правой кнопкой на Solution и выбираем Configure Startup Projects и выбираем всё как на скрине(Обязательнно выбираем https). Это делается для того чтобы запускался клиент и сервер.
6. <img width="388" height="605" alt="image" src="https://github.com/user-attachments/assets/e478e1d1-a0a9-4ca0-bd6f-b5d8c8a3f80d" />
7. После этого можно запустить проект. Откроется две веб странички. Переходи к страничке с Blazor.
8. Слева можно будет выбрать странички для создания либо просмотра записей.
9. <img width="249" height="953" alt="image" src="https://github.com/user-attachments/assets/2e2f59ed-aa3a-489d-a196-84e12e16d056" />
10. Создаете работников
11. <img width="1668" height="742" alt="image" src="https://github.com/user-attachments/assets/42fd7b2a-b81a-479d-9b94-850ce2270eec" />
12. Созданные работники появятся в Employees где вы сможите их удалять либо редактировать.
13. <img width="1663" height="816" alt="image" src="https://github.com/user-attachments/assets/ecb7bb6b-ae3f-49a7-b615-a590b9f7c8e1" />
14. Все также работает с проектами.
