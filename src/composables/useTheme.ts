import { ref, computed } from 'vue'

const theme = ref<boolean>(false)

export function useTheme() {
  const toggleTheme = () => {
    document.documentElement.classList.toggle('dark');
    theme.value = !theme.value
  }

  const isDark = computed(() => theme.value)

  return {
    theme,
    toggleTheme,
    isDark,
  }
}