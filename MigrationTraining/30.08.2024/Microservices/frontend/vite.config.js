import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    host: true, // Listen on all network interfaces
    port: 3000, // Specify the port to 3000
  },
  preview: {
    port: 3000, // Ensure the preview mode runs on port 3000
  },
});