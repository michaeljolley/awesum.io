import { getInstance } from "./authService";

export const authGuard = (to, from, next) => {
  const authService = getInstance();

  const fn = () => {
    if (!authService.isAuthenticated) {
      authService.loginWithRedirect({ appState: { targetUrl: to.fullPath } });
    }

    if (!to.meta.claimName || authService.hasTokenClaim(to.meta.claimName)) {
      return next();
    } else {
      return next("/");
    }
  };

  if (!authService.loading) {
    return fn();
  }

  authService.$watch("loading", loading => {
    if (loading === false) {
      return fn();
    }
  });
};
