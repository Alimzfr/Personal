export interface LoginModel {
  username: string;
  password: string;
}

export interface TokenModel {
  access_token: string;
  refresh_token: string;
}

export interface AuthResponseModel {
  userName: string;
  displayName: string;
  email: string;
  accessToken: string;
  refreshToken: string;
  accessTokenExpirationDate: Date;
  refreshTokenExpirationDate: Date;
}

export class User {
  constructor(private authData: AuthResponseModel) {
  }

  get accessToken() {
    return this.authData.accessToken;
  }

  get refreshToken() {
    return this.authData.refreshToken;
  }

  get displayName() {
    return this.authData.displayName;
  }

  get email() {
    return this.authData.email;
  }
}
