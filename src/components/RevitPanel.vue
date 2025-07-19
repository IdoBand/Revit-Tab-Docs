<script setup lang="ts">
import { defineProps } from 'vue'

type Props = {
  title: string
}

defineProps<Props>()
</script>

<template>
  <div class="revit-panel" >
    <div class="revit-panel__content">
      <slot></slot>
    </div>
    <div class="revit-panel__title">
      {{ title }}
    </div>
  </div>
</template>

<style scoped>
.revit-panel {
  display: flex;
  flex-direction: column;
  min-width: max-content;
  height: max-content;
  border-right: 1px solid #a0a0a0;
  background: linear-gradient(to bottom, #f5f5f5 0%, #e8e8e8 100%);
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.3);
}

.revit-panel:last-child {
  border-right: none;
}

.revit-panel__content {
  flex: 1;
  display: flex;
  flex-wrap: wrap;
  align-content: flex-start;
  padding: 4px 2px 2px 2px;
  gap: 1px;
  min-height: 70px;
}

.revit-panel__title {
  text-align: center;
  width: 100%;
  color: #2c2c2c;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  font-size: 11px;
  line-height: 12px;
  padding: 2px 4px 4px 4px;
  background: linear-gradient(to bottom, #e8e8e8 0%, #d8d8d8 100%);
  border-top: 1px solid #a0a0a0;
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2);
}
</style>