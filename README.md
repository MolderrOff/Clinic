Репозиторий состоит из двух папок: ClinicVS22 - решение VStudio C#, react-vite-intro - страница на React.\
Для запуска установите свой SqlConnection в appsetings.json, и/или в классе InfrastructureConfigurator, если используете\
не MS SQL. В program.cs поменяйте builder.WithOrigins свой хост и/или порт на свои в случае необходимости для\ 
коннекта с React страницей.\
*Описание программы*\
Создана БД со следующими сущностями (пациент(Patients), доктор (Doctors), болезни(Diseases)).\
Созданы контроллеры на вывод информации о каждом пациенте, о всех пациентах.\
Информация о докторах по специальностям\
Также общий список болезней, сделан 1 контроллер на обновление данных.\
Добавлена для получения данных простенькая страничка на React.\

Порядок сборки решения C#\
Создайте базу данных миграцией в папке Clinic.Infrastructure\
командой Update-Database\
Clinic.sln в папке Clinic\
apt install -y dotnet-sdk-9.0\
dotnet restore\
dotnet build\

Запустить React командой\
*npm run dev* в папке react-vite-intro
