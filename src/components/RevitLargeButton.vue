<script setup lang="ts">
import { defineProps } from 'vue'
import { setSelectedButton, selectedButton } from '../composables/useSelectedButton';
import type { RevitButtonProps } from '../assets/types';

defineProps<RevitButtonProps>()
console.log()
</script>

<template>
  <button
    class="revit-tab-button"
    @click="setSelectedButton(label)"
    :class="{'selected': selectedButton.label === label}"
  >
    <div class="revit-tab-button__icon">
      <img 
        :src="imageSrc" 
        :alt="label" 
        class="revit-tab-button__image"
      />
    </div>
    <div class="revit-tab-button__label">
      {{ label }}
    </div>
  </button>
</template>

<style scoped>
.revit-tab-button {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
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

.revit-tab-button.selected {
  background: linear-gradient(to bottom, #fbfbfb 0%, #c3c3c3 100%);
}

.revit-tab-button:hover {
  background: linear-gradient(to bottom, #f8f8f8 0%, #ebebeb 100%);
  border-color: #a0a0a0;
  box-shadow: 
    inset 0 1px 0 rgba(255, 255, 255, 0.4),
    0 1px 3px rgba(0, 0, 0, 0.15);
}

.revit-tab-button:active,
.revit-tab-button--active {
  background: linear-gradient(to bottom, #d8d8d8 0%, #e5e5e5 100%);
  border-color: #7a7a7a;
  box-shadow: 
    inset 0 1px 3px rgba(0, 0, 0, 0.2),
    inset 0 0 5px rgba(0, 0, 0, 0.1);
  transform: translateY(1px);
}

.revit-tab-button__icon {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-bottom: 2px;
}

.revit-tab-button__image {
  width: 32px;
  height: 32px;
  object-fit: contain;
  display: block;
}

.revit-tab-button__label {
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

.revit-tab-button:focus {
  outline: none;
}

.revit-tab-button:disabled {
  opacity: 0.6;
  cursor: not-allowed;
  background: #f0f0f0;
  color: #999;
}

.revit-tab-button:disabled:hover {
  background: #f0f0f0;
  border-color: #c8c8c8;
  box-shadow: none;
}
</style>