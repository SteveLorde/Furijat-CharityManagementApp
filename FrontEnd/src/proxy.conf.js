const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "https://localhost:5001",
    secure: false
  },
  {
    context: [
      "/api2",
    ],
    target: "https://localhost:7272",
    secure: false,
  }
]

module.exports = PROXY_CONFIG;
