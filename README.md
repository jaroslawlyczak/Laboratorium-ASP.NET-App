# Przegląd projektu Reservation:

Projekt dotyczy systemu rezerwacji, umożliwiającego zarządzanie danymi dotyczącymi rezerwacji

**Lista wykorzystanych technologii:**
- ASP.NET Core 7.0
- ASP.NET Core Web API
- Entity Framework Core z bazą danych SQLite
- Microsoft Identity
- Bootstrap
- XUnit do testów

**Dane przykładowych użytkowników:**

*Administrator:*
- *Login:* adam@wsei.edu.pl
- *Hasło:* 1234Abcd$

*User:*
- *Login:* ewa@wsei.edu.pl
- *Hasło:* Ewa123!


# Proces Uruchomienia Aplikacji

1. **Klonowanie repozytorium:** Sklonuj repozytorium z GitHub.
2. **Instalacja zależności:** Użyj `dotnet restore` w katalogu projektu, aby zainstalować zależności.
3. **Migracja bazy danych:** Uruchom `dotnet ef database update`, aby zastosować migracje do bazy danych SQLite.
4. **Uruchomienie aplikacji:** Użyj `dotnet run` w katalogu projektu, aby uruchomić aplikację.


# Wykonane zostały następujące elementy aplikacji:

**Zapisanie Danych w Bazie z wykorzystaniem Entity Framework:**

- Wykorzystano Entity Framework Core z bazą danych SQLite.
- Dodano przykładowe dane.

**Istnienie Związków:**

- Zdefiniowano trzy związki: organizacje i kontakty, kontakty i rezerwacje, rezerwacje i szczegóły pokoju.

**Moduł Identity:**

- Dodano moduł Identity do logowania użytkowników.
- Utworzono dwie role: administrator i zwykły użytkownik.

**Formularze do Realizacji CRUD i Widoki z Dostępem dla Administratora:**

- Opracowano formularze do obsługi CRUD oraz widoki z listami obiektów.
- Zapewniono dostęp do nich tylko dla administratora.
  
**Funkcje Charakterystyczne Aplikacji:**

- Wyszukiwanie rezerwacji.
- Sortowanie rezerwacji.
- Stronicowanie strony.
  
**Serwis do Obsługi Funkcji CRUD:**

- Wykonany serwis umożliwiający operacje CRUD na danych.

**Moduł Testów Jednostkowych:**

- Dodano testy jednostkowe dla kontrolerów kontaktów i rezerwacji.

**Kontroler WEBAPI do Udostępniania Wybranych Danych:**

- Dodano kontroler WEBAPI dla wyszukiwania właścicieli rezerwacji.

**Zmodyfikowano Wygląd Aplikacji:**

- Wygląd strony został stworzony przy użyciu Tailwind CSS.

**Program Działa Asynchronicznie:**

- Projekt został stworzony z wykorzystaniem asynchronicznych operacji przy użyciu async, await oraz Task.
  
