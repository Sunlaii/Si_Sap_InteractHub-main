import { Suspense, lazy } from 'react';
import { createBrowserRouter } from 'react-router';
import { AdminRoute, GuestRoute, ProtectedRoute } from './components/RouteGuards';

const Layout = lazy(() => import('./components/Layout'));
const HomePage = lazy(() => import('./pages/HomePage'));
const LoginPage = lazy(() => import('./pages/LoginPage'));
const RegisterPage = lazy(() => import('./pages/RegisterPage'));
const ProfilePage = lazy(() => import('./pages/ProfilePage'));
const HashtagPage = lazy(() => import('./pages/HashtagPage'));
const SearchPage = lazy(() => import('./pages/SearchPage'));
const FriendsPage = lazy(() => import('./pages/FriendsPage'));
const NotificationsPage = lazy(() => import('./pages/NotificationsPage'));
const AdminPage = lazy(() => import('./pages/AdminPage'));
const NotFoundPage = lazy(() => import('./pages/NotFoundPage'));

const withSuspense = (component: React.ReactElement) => (
  <Suspense fallback={<div className="p-6 text-sm text-gray-500">Đang tải...</div>}>
    {component}
  </Suspense>
);

export const router = createBrowserRouter([
  {
    path: '/',
    element: withSuspense(
      <ProtectedRoute>
        <Layout />
      </ProtectedRoute>,
    ),
    children: [
      { index: true, element: withSuspense(<HomePage />) },
      { path: 'profile/:userId?', element: withSuspense(<ProfilePage />) },
      { path: 'hashtag/:tag', element: withSuspense(<HashtagPage />) },
      { path: 'search', element: withSuspense(<SearchPage />) },
      { path: 'friends', element: withSuspense(<FriendsPage />) },
      { path: 'notifications', element: withSuspense(<NotificationsPage />) },
      {
        path: 'admin',
        element: withSuspense(
          <AdminRoute>
            <AdminPage />
          </AdminRoute>,
        ),
      },
    ],
  },
  {
    path: '/login',
    element: withSuspense(
      <GuestRoute>
        <LoginPage />
      </GuestRoute>,
    ),
  },
  {
    path: '/register',
    element: withSuspense(
      <GuestRoute>
        <RegisterPage />
      </GuestRoute>,
    ),
  },
  { path: '*', element: withSuspense(<NotFoundPage />) },
]);
