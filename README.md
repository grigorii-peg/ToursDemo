# ToursDemo
Пегушин Григорий Алексеевич ИП-20-3  
Тема задания: Заказ туров

## Схема базы данных
```mermaid
erDiagram

    Users {
        int Id
        string LastName
        string FirstName
        string Patronymic
        string Login
        string Password
        Role RoleId
    }

    Countries {
        string Code
        string Name
    }

    TypeTours {
        int Id
        string Name
        string Description
    }
    
    Hotels {
        int Id
        string Title
        int CountOfStars
        string CountryCode
        string Description
    }
    
    HotelCommets {
        int Id
        int HotelId
        string Text
        int UserId
    }

    ReceivingPoints {
        int Id
        string Title
        string Address
    }

     Tours {
        int Id
        int TicketCount
        string CountryCode
        string Title
        string Description
        byte[] ImagePreview
        decimal Price
        bool IsActual
    }

     Orders {
        int Id
        int UserId
        decimal Price
        DateTime OrderDate
        int AllSale
        DateTime DateReceipt
        int ReceivingPointId
        int Code
    }
    Countries ||--o{ Hotels: is
    Countries ||--o{ Tours: is
    TypeTours ||--o{ Tours: is
    Hotels ||--o{ HotelCommets: is
    Users ||--o{ HotelCommets: is
    Users ||--o{ Orders: is
    ReceivingPoints ||--o{ Orders: is
    Hotels ||--o{ Tours: is
    TypeTours ||--o{ Tours: is
    Orders ||--o{ Tours: is

  BaseAuditEntity {
        Guid ID
        DateTimeOffset CreatedAt
        string CreatedBy
        DateTimeOffset UpdatedAt
        string UpdatedBy
        DateTimeOffset DeleteddAt
  }
```

## Диаграмму последовательности авторизации
```mermaid
sequenceDiagram
actor U as User
participant UI
participant CB as Code Behind
participant DB as Database
U->>UI:ввод авторизационных данных
UI->>CB:передача данных
CB->>CB:валидация
CB->>DB:поиск пользователя
DB-->>CB:результат поиска
CB->>UI:сообщение об успешности
```

## Скрипт заполнения БД
﻿INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AD', N'Andorra')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AE', N'United Arab Emirates')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AF', N'Afghanistan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AG', N'Antigua and Barbuda')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AI', N'Anguilla')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AL', N'Albania')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AM', N'Armenia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AN', N'Netherlands Antilles')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AO', N'Angola')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AQ', N'Antarctica')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AR', N'Argentina')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AS', N'American Samoa')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AT', N'Austria')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AU', N'Australia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AW', N'Aruba')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AX', N'Aland Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'AZ', N'Azerbaijan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BA', N'Bosnia and Herzegovina')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BB', N'Barbados')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BD', N'Bangladesh')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BE', N'Belgium')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BF', N'Burkina Faso')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BG', N'Bulgaria')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BH', N'Bahrain')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BI', N'Burundi')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BJ', N'Benin')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BL', N'Saint BarthГ©lemy')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BM', N'Bermuda')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BN', N'Brunei')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BO', N'Bolivia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BQ', N'Bonaire, Saint Eustatius and Saba')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BR', N'Brazil')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BS', N'Bahamas')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BT', N'Bhutan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BV', N'Bouvet Island')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BW', N'Botswana')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BY', N'Belarus')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'BZ', N'Belize')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CA', N'Canada')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CC', N'Cocos Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CD', N'Democratic Republic of the Congo')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CF', N'Central African Republic')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CG', N'Republic of the Congo')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CH', N'Switzerland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CI', N'Ivory Coast')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CK', N'Cook Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CL', N'Chile')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CM', N'Cameroon')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CN', N'China')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CO', N'Colombia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CR', N'Costa Rica')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CS', N'Serbia and Montenegro')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CU', N'Cuba')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CV', N'Cape Verde')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CW', N'CuraГ§ao')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CX', N'Christmas Island')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CY', N'Cyprus')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'CZ', N'Czech Republic')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DE', N'Germany')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DJ', N'Djibouti')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DK', N'Denmark')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DM', N'Dominica')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DO', N'Dominican Republic')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'DZ', N'Algeria')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'EC', N'Ecuador')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'EE', N'Estonia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'EG', N'Egypt')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'EH', N'Western Sahara')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ER', N'Eritrea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ES', N'Spain')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ET', N'Ethiopia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FI', N'Finland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FJ', N'Fiji')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FK', N'Falkland Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FM', N'Micronesia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FO', N'Faroe Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'FR', N'France')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GA', N'Gabon')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GB', N'United Kingdom')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GD', N'Grenada')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GE', N'Georgia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GF', N'French Guiana')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GG', N'Guernsey')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GH', N'Ghana')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GI', N'Gibraltar')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GL', N'Greenland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GM', N'Gambia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GN', N'Guinea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GP', N'Guadeloupe')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GQ', N'Equatorial Guinea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GR', N'Greece')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GS', N'South Georgia and the South Sandwich Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GT', N'Guatemala')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GU', N'Guam')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GW', N'Guinea-Bissau')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'GY', N'Guyana')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HK', N'Hong Kong')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HM', N'Heard Island and McDonald Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HN', N'Honduras')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HR', N'Croatia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HT', N'Haiti')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'HU', N'Hungary')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ID', N'Indonesia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IE', N'Ireland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IL', N'Israel')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IM', N'Isle of Man')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IN', N'India')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IO', N'British Indian Ocean Territory')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IQ', N'Iraq')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IR', N'Iran')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IS', N'Iceland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'IT', N'Italy')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'JE', N'Jersey')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'JM', N'Jamaica')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'JO', N'Jordan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'JP', N'Japan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KE', N'Kenya')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KG', N'Kyrgyzstan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KH', N'Cambodia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KI', N'Kiribati')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KM', N'Comoros')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KN', N'Saint Kitts and Nevis')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KP', N'North Korea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KR', N'South Korea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KW', N'Kuwait')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KY', N'Cayman Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'KZ', N'Kazakhstan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LA', N'Laos')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LB', N'Lebanon')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LC', N'Saint Lucia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LI', N'Liechtenstein')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LK', N'Sri Lanka')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LR', N'Liberia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LS', N'Lesotho')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LT', N'Lithuania')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LU', N'Luxembourg')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LV', N'Latvia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'LY', N'Libya')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MA', N'Morocco')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MC', N'Monaco')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MD', N'Moldova')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ME', N'Montenegro')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MF', N'Saint Martin')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MG', N'Madagascar')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MH', N'Marshall Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MK', N'Macedonia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'ML', N'Mali')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MM', N'Myanmar')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MN', N'Mongolia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MO', N'Macao')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MP', N'Northern Mariana Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MQ', N'Martinique')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MR', N'Mauritania')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MS', N'Montserrat')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MT', N'Malta')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MU', N'Mauritius')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MV', N'Maldives')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MW', N'Malawi')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MX', N'Mexico')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MY', N'Malaysia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'MZ', N'Mozambique')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NA', N'Namibia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NC', N'New Caledonia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NE', N'Niger')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NF', N'Norfolk Island')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NG', N'Nigeria')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NI', N'Nicaragua')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NL', N'Netherlands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NO', N'Norway')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NP', N'Nepal')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NR', N'Nauru')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NU', N'Niue')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'NZ', N'New Zealand')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'OM', N'Oman')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PA', N'Panama')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PE', N'Peru')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PF', N'French Polynesia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PG', N'Papua New Guinea')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PH', N'Philippines')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PK', N'Pakistan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PL', N'Poland')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PM', N'Saint Pierre and Miquelon')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PN', N'Pitcairn')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PR', N'Puerto Rico')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PS', N'Palestinian Territory')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PT', N'Portugal')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PW', N'Palau')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'PY', N'Paraguay')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'QA', N'Qatar')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'RE', N'Reunion')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'RO', N'Romania')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'RS', N'Serbia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'RU', N'Russia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'RW', N'Rwanda')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SA', N'Saudi Arabia')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SB', N'Solomon Islands')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SC', N'Seychelles')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SD', N'Sudan')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SE', N'Sweden')
INSERT [dbo].[Countries] ([Code], [Name]) VALUES (N'SG', N'Singapore')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Hotel Artemide', 5, N'ES', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'H10 Madison', 4, N'FI', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'A Room With A View', 3, N'ES', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Hotel Rec Barcelona', 5, N'ES', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Aydinli Cave Hotel', 2, N'ES', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Titanic Business Kartal', 3, N'ES', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Amber Design Residence', 3, N'FI', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Hotel Al Ponte Mocenigo', 5, N'RU', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'La Cachette', 4, N'RU', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Celsus Boutique Hotel', 3, N'GB', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Ashford Castle', 2, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Agarta Cave Hotel', 5, N'GB', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Sofitel Grand Sopot', 5, N'FI', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Grand Resort Bad Ragaz', 4, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Kelebek Special Cave Hotel', 5, N'GB', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'A Room With A View', 3, N'GB', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Aren Cave Hotel & Art Gallery', 5, N'GE', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'La Cachette', 4, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Castle Hotel Auf Schoenburg', 3, N'GE', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Lawton & Lauriston Court Hotel', 5, N'GB', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Elif Hanim Hotel & Spa', 3, N'RU', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'A Room With A View', 3, N'ES', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Boutique Hotel Sierra de Alicante', 3, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Van der Valk Hotel Hoorn', 4, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Up Hotel', 5, N'RU', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Dere Suites', 5, N'FI', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Park Dedeman Trabzon', 3, N'RU', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Duven Hotel', 5, N'FI', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Elif Hanim Hotel & Spa', 3, N'RU', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Bandholm Hotel', 2, N'GE', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Boutique Hotel El Cresol', 4, N'HR', N'Классный отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Perimasali Cave Hotel - Cappadocia', 3, N'HR', N'Крутой отель')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Gul Konaklari - Sinasos Rose Mansions', 5, N'HR', N'')
INSERT [dbo].[Hotels] ([Title], [CountOfStars], [CountryCode], [Description]) VALUES (N'Test', 0, N'AD', N'Описание')
INSERT [dbo].[ReceivingPoints] ([Title], [Address]) VALUES (N'Озон', N'Ул. Героев Тулы, д. 13, корп. 8')
INSERT [dbo].[ReceivingPoints] ([Title], [Address]) VALUES (N'Яндекс Маркет', N'Большевиков пр-т, д. 21/39, кв. 382')
INSERT [dbo].[ReceivingPoints] ([Title], [Address]) VALUES (N'Озон', N'Топольчанская, д. 1/А, оф. 159')
INSERT [dbo].[ReceivingPoints] ([Title], [Address]) VALUES (N'Яндекс Маркет', N'Терзарина улица, д. 23, оф. 145')
INSERT [dbo].[ReceivingPoints] ([Title], [Address]) VALUES (N'Озон', N'Туапсинская улица, д. 14, оф. 12')
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (100, N'BG', N'Болгарское Наследие', N'', NULL, CAST(10000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (92, N'AE', N'Волшебный Восток', N'', NULL, CAST(77100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (72, N'DE', N'Город с большими амбициями', N'Класс', NULL, CAST(93300.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (143, N'DE', N'Город четырех ворот', N'', NULL, CAST(72500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (34, N'AT', N'Горячий отдых зимой и летом', N'', NULL, CAST(31900.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (43, N'BY', N'Древний Минск', N'', NULL, CAST(74900.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (224, N'RU', N'Жемчужина Татарстана', N'Вау', NULL, CAST(65100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (283, N'NL', N'Знакомьтесь, Амстердам!', N'', NULL, CAST(68300.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (215, N'KR', N'Многоликий Сувон', N'', NULL, CAST(62200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (30, N'RU', N'Москва поэтическая', N'', NULL, CAST(53200.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (250, N'IN', N'Незабываемый Дели', N'Респект', NULL, CAST(22500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (60, N'EE', N'По старому Таллину', N'', NULL, CAST(28800.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (120, N'GR', N'Прекрасные острова Греции', N'', NULL, CAST(53700.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (101, N'RU', N'Романтика белых ночей и разводных мостов', N'', NULL, CAST(54900.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (161, N'FI', N'Свидание с Хельсинки', N'', NULL, CAST(49100.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (99, N'IR', N'Сердце Ирана', N'Ну это просто', NULL, CAST(71400.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (25, N'FI', N'Сердце Северной Карелии', N'', NULL, CAST(62000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (38, N'SE', N'Старый город', N'', NULL, CAST(25600.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (292, N'KR', N'Столица страны Утренней Свежести', N'Вот это да', NULL, CAST(27600.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (223, N'CN', N'Страна идеальной гармонии', N'', NULL, CAST(28700.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (22, N'BR', N'Урбанистическая Бразилия', N'', NULL, CAST(80900.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (115, N'FI', N'Финская крепость', N'', NULL, CAST(70700.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Tours] ([TicketCount], [CountryCode], [Title], [Description], [ImagePreview], [Price], [IsActual]) VALUES (289, N'FI', N'Финский романтизм', N'', NULL, CAST(93600.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Международный туризм', N'Круто')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Лечебно-оздоровительные туры', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Пляжные туры', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Экскурсионные туры', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Обслуживание корпоративных клиентов по заказу', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Специализированные детские туры', N'Класс')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Культурно-исторические туры', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Внутренний туризм', N'')
INSERT [dbo].[TypeTours] ([Name], [Description]) VALUES (N'Горнолыжные курорты', N'Вау')
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (1, 1)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 1)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (2, 2)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 2)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 3)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 3)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (7, 3)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 4)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 4)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 4)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (1, 5)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 5)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 6)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (4, 6)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 6)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (7, 6)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 6)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 7)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (6, 7)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 7)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 8)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 8)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 10)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 10)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (4, 11)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (6, 11)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 12)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 12)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 14)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 14)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 14)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 15)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 16)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (6, 16)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (7, 16)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 17)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 17)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 18)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (7, 18)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 18)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 19)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (9, 19)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 20)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 20)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 20)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 21)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (1, 22)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 22)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (2, 24)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 24)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 24)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (3, 25)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (4, 25)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 25)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (8, 25)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (5, 26)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (7, 26)
INSERT [dbo].[TypeTourTours] ([TypeTour_Id], [Tour_Id]) VALUES (9, 26)
INSERT [dbo].[Users] ([FirstName], [LastName], [Patronymic], [Login], [Password], [Role]) VALUES (N'Иван', N'Иванов', N'Иванович', N'Ivan', N'3412', 1)
INSERT [dbo].[Users] ([FirstName], [LastName], [Patronymic], [Login], [Password], [Role]) VALUES (N'Меньшиков', N'Данила', N'Александрович', N'Danila', N'8841', 2)
INSERT [dbo].[Users] ([FirstName], [LastName], [Patronymic], [Login], [Password], [Role]) VALUES (N'Коноплев', N'Анатолий', N'Александрович', N'Toliy', N'4321', 3)
