# RealEstateFilters
Barfoot and Thompson filters test

Contains a repository for Playwright and Specflow with .NET language binding

# Playwright Architecture

```mermaid
graph TB
  U["C#/Java/Python/TS SDK"] -- "Write Test" --> PT["Playwright Test"]
  PT -- "Uses" --> P["Playwright Driver"]
  P -- "Uses" --> C["Chromium"]
  P -- "Uses" --> F["Firefox"]
  P -- "Uses" --> S["Safari"]
  C -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]

  F -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]

  S -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]
  linkStyle 0 stroke:#2ecd71,stroke-width:2px;
  linkStyle 1 stroke:#2ecd71,stroke-width:2px;
  linkStyle 2 stroke:#2ecd71,stroke-width:2px;
  linkStyle 3 stroke:#2ecd71,stroke-width:2px;
  linkStyle 4 stroke:#2ecd71,stroke-width:2px;
  linkStyle 5 stroke:#2ecd71,stroke-width:2px;
  linkStyle 6 stroke:#2ecd71,stroke-width:2px;
  ```

  This project run in headfull browser mode.

  Objective
1. Navigate to www.barfoot.co.nz
2. Write automated tests that cover possible scenarios for:
a. Searching listings using suburb, bedroom and bathroom filters.
b. Search listings using suburb, price, property type and land area filter.

