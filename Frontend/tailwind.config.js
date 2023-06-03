/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      container: {
        center: true,
      },
      colors: {
        "neutral": {
          100: "#ffffff",
          200: "#eef1ff",
          900: "#080b19"
        },
        "primary": {
          200: "#97aaff",
          300: "#758dff",
          DEFAULT: "#5271ff",
          500: "#4a66e6",
          600: "#314499",
        },
        "accent": "#ed2939",
      },
    },
    plugins: [],
  }
}