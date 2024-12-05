import {BrowserRouter, Navigate, Route, Routes} from "react-router";
import Layout from "./Pages/Layout.jsx";
import NofFoundPage from "./Pages/NofFoundPage/index.jsx";
import LoginPage from "./Pages/LoginPage/index.jsx";
import DashboardPage from "./Pages/DashboardPage/index.jsx";
import ResourcesPage from "./Pages/ResourcesPage/index.jsx";
import LanguagesPage from "./Pages/LanguagesPage/index.jsx";
import {ProtectedRoute} from "./Components/ProtectedRoute.jsx";
import TranslationsPage from "./Pages/TranslationsPage/index.jsx";

function App() {

  return (
      <>
          <BrowserRouter>
              <Routes>
                  <Route path="/" element={<Layout/>}>
                      <Route index element={<LoginPage/>}/>
                      <Route path="login" element={<Navigate to="/"/>}/>
                      <Route path="dashboard" element={
                          <ProtectedRoute>
                              <DashboardPage/>
                          </ProtectedRoute>}>
                          <Route index element={<ResourcesPage/>}/>
                          <Route path="languages" element={<LanguagesPage/>}/>
                          <Route path="translations" element={<TranslationsPage/>}/>
                      </Route>
                      <Route path="logout" element={<Navigate to="/"/>}/>
                      <Route path="*" element={<NofFoundPage/>} />
                  </Route>
              </Routes>
          </BrowserRouter>
      </>

  )
}

export default App
