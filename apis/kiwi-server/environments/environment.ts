export const environment = {
    name: '',
    jwt: {
      secret: process.env.JWT_SECRET,
      timestamp: 60
    },
    password_secret: process.env.PASSWORD_SECRET
}