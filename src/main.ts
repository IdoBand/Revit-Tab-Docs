import { createApp } from 'vue'
import './style.css'
import PrimeVue from 'primevue/config';
import { preset } from '../PrimeVuePreset'
import App from './App.vue'

const app = createApp(App);

app.use(PrimeVue, {
    theme: {
        preset: preset,
        options: {
            darkModeSelector: '.dark',  
        }
    }
})

app.mount('#app')