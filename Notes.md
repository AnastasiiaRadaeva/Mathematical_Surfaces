* Division requires a bit more work than multiplication, so it's a rule of thumb to prefer multiplication over division. However, constant expressions like 1f / 2f and also 2f * Mathf.PI are already reduced to a single number by the compiler.
    ```c#
  y += Sin(2f * PI * (x + t)) * (1f / 2f); // faster than Sin(2f * PI * (x + t)) / 2f
  return y * (2f / 3f); // faster than y / 1.5f;
    ```