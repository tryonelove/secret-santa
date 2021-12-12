import { BrowserRouter, Route, Routes } from 'react-router-dom';
import App from './App';
import { Registration } from './components/Registration';

export function AppContainer() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<App />}>
          <Route path='register' element={<Registration />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
