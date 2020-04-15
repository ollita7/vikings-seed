export const environment = {
    name: 'prod',
    jwt: {
      secret: process.env.JWT_SECRET,
      timestamp: 60
    }
}