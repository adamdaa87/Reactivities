# Reactivities
## Reactivities — What I built

I built a full-stack Activities app with a clean separation of concerns, a CQRS-style backend, and a typed React UI.

### Backend (API)
- 🧭 **ASP.NET Core 8** Web API with DI & CORS
- 📬 **MediatR (CQRS)**: handlers for **List**, **Details**, **Create**, **Edit**, **Delete**
- 🧰 **EF Core** + 🗄️ **SQLite**: `AppDbContext`, migrations, seeding
- 🔁 **AutoMapper**: central `MappingProfiles`
- ♻️ Async endpoints returning typed results

### Frontend (Client)
- ⚛️ **React 18** + 🟦 **TypeScript** (Vite)
- 🎨 **Material UI**: layout with `Grid`, `Box`, `Paper`, `Typography`, `Button`
- 🌐 **axios** data layer (`/api/activities`)
- 🧩 Screens/components: `NavBar`, `ActivityDashboard`, `ActivityList`, `ActivityDetail`, `ActivityForm`
- 🔐 Strong typing of models (`Activity`), hooks (`useState`, `useEffect`)
- 🖼️ Public **assets** for category images; theme-aware styling via `sx`

### What I implemented
- Fetch, display, and **map** activities into cards
- **Select** an activity to view details; **edit/create** via a form
- Immutable state updates (e.g., `map` replace on edit, array spread on create)
- Simple id generation for new items (later swappable for server IDs)
- Clean UI with responsive spacing and consistent MUI styling
