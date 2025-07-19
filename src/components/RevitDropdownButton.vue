<script setup lang="ts">
import { defineProps, ref, onMounted, onUnmounted } from 'vue'

type Props = {
  imageSrc: string
  label: string
  isActive?: boolean
}

defineProps<Props>()
  
const isDropdownOpen = ref(false)
const buttonRef = ref<HTMLElement | null>(null)
const dropdownRef = ref<HTMLElement | null>(null)

const toggleDropdown = () => {
  isDropdownOpen.value = !isDropdownOpen.value
}

const closeDropdown = () => {
  isDropdownOpen.value = false
}

const handleClickOutside = (event: MouseEvent) => {
  if (buttonRef.value && dropdownRef.value) {
    if (!buttonRef.value.contains(event.target as Node) && 
        !dropdownRef.value.contains(event.target as Node)) {
      isDropdownOpen.value = false
    }
  }
}

onMounted(() => {
  document.addEventListener('click', handleClickOutside)
})

onUnmounted(() => {
  document.removeEventListener('click', handleClickOutside)
})

defineExpose({
  closeDropdown
})
</script>

<template>
  <div class="revit-dropdown-container">
    <button
      ref="buttonRef"
      class="revit-dropdown-button"
      @click="toggleDropdown"
      :class="{ 
        'revit-dropdown-button--active': isActive,
        'revit-dropdown-button--open': isDropdownOpen
      }"
    >
      <div class="revit-dropdown-button__icon">
        <img 
          :src="imageSrc" 
          :alt="label" 
          class="revit-dropdown-button__image"
        />
      </div>
      <div class="revit-dropdown-button__label">
        {{ label }}
      </div>
    </button>
    
    <div 
      v-if="isDropdownOpen"
      ref="dropdownRef"
      class="revit-dropdown-menu"
    >
      <slot />
    </div>
  </div>
</template>

<style scoped>
.revit-dropdown-container {
  position: relative;
  display: inline-block;
}

.revit-dropdown-button {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  position: relative;
  width: 60px;
  height: 70px;
  padding: 6px 4px 4px 4px;
  margin: 0;
  border: 1px solid #c8c8c8;
  border-radius: 3px;
  background: linear-gradient(to bottom, #f5f5f5 0%, #e8e8e8 100%);
  color: #2c2c2c;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  font-size: 11px;
  font-weight: normal;
  cursor: pointer;
  transition: all 0.1s ease-in-out;
  box-shadow: 
    inset 0 1px 0 rgba(255, 255, 255, 0.3),
    0 1px 2px rgba(0, 0, 0, 0.1);
}

.revit-dropdown-button:hover {
  background: linear-gradient(to bottom, #f8f8f8 0%, #ebebeb 100%);
  border-color: #a0a0a0;
  box-shadow: 
    inset 0 1px 0 rgba(255, 255, 255, 0.4),
    0 1px 3px rgba(0, 0, 0, 0.15);
}

.revit-dropdown-button:active,
.revit-dropdown-button--active,
.revit-dropdown-button--open {
  background: linear-gradient(to bottom, #d8d8d8 0%, #e5e5e5 100%);
  border-color: #7a7a7a;
  box-shadow: 
    inset 0 1px 3px rgba(0, 0, 0, 0.2),
    inset 0 0 5px rgba(0, 0, 0, 0.1);
  transform: translateY(1px);
}

.revit-dropdown-button__icon {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 2px;
}

.revit-dropdown-button__image {
  width: 32px;
  height: 32px;
  object-fit: contain;
  display: block;
}

.revit-dropdown-button__label {
  text-align: center;
  line-height: 12px;
  max-width: 52px;
  word-wrap: break-word;
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
}


.revit-dropdown-button:focus {
  outline: none;
}

.revit-dropdown-button:disabled {
  opacity: 0.6;
  cursor: not-allowed;
  background: #f0f0f0;
  color: #999;
}

.revit-dropdown-button:disabled:hover {
  background: #f0f0f0;
  border-color: #c8c8c8;
  box-shadow: none;
}

.revit-dropdown-menu {
  position: absolute;
  top: 100%;
  left: 0;
  min-width: 150px;
  background: #f5f5f5;
  border: 1px solid #c8c8c8;
  border-radius: 3px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
  z-index: 1000;
  overflow: hidden;
  display: flex;
  flex-direction: column;
}
</style>