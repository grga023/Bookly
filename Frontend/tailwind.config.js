/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
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
    keyframes: {
      "accordion-down": {
        from: { height: 0 },
        to: { height: "var(--radix-accordion-content-height)" },
      },
      "accordion-up": {
        from: { height: "var(--radix-accordion-content-height)" },
        to: { height: 0 },
      },
    },
    animation: {
      "accordion-down": "accordion-down 0.2s ease-out",
      "accordion-up": "accordion-up 0.2s ease-out",
    },
    plugins: [],
  }
}