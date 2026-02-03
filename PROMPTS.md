# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | X |
| Kullanılan araçlar | ChatGPT / Claude / Copilot |
| En çok yardım alınan konular | [liste] |
| Tahmini LLM ile kazanılan süre | X saat |

---

## Prompt 1: Multiple Collider algılayan yöntemler

**Araç:** Gemini
**Tarih/Saat:** 2026.02.03 21.07

**Prompt:**
```
can you give me basic example of raycast and OnTrigger based which can detect multiple collider in player range?

Which raycast or cast option should be fit best for my question?
```

**Alınan Cevap (Özet):**
```
To detect multiple colliders within a player's range, a standard single Raycast (which shoots a thin line) is usually not the right tool because it typically hits only the first thing it sees or requires a very specific angle.

Instead, for "Raycast-style" logic, you want to use Physics.OverlapSphere (an instant check of an area) or Physics.SphereCastAll (sweeping a shape).

Here are the two best basic examples: one using a Trigger Collider (passive/persistent) and one using Physics.OverlapSphere (active/instant).

The Trigger Method (Passive)
This is best if you need to keep a permanent list of enemies/items near the player (e.g., to show a "Pick Up" UI when close).

How it works: You add a Sphere Collider to your player, check "Is Trigger," and let Unity's physics engine do the work. ... 


```

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [X] Reddettim (kullanmadım)

**Açıklama:**
Aklımda zaten multiple colliderları tespit edecek birkaç fikir vardı. Sadece bana önereceği daha iyi yöntem var mı yok mu diye sordum. Şimdilik en basit haliyle kafamdaki düşünceyle bir list aracılığıyla OnTriggerEnter ve OnTriggerExit sayesinde current interactables objelerini güncelliyorum ve en yakındaki interactable objeyi seçiyorum FindClosestInteractable methoduyla.

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Prompt 2: [Konu Başlığı]

**Araç:** [ChatGPT-4 / Claude / GitHub Copilot]
**Tarih/Saat:** YYYY-MM-DD HH:MM

**Prompt:**
```
[Yazdığınız prompt]
```

**Alınan Cevap (Özet):**
```
[Cevap özeti]
```

**Nasıl Kullandım:**
- [ ] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Açıklama]

---

## Prompt 3: ...

[Diğer promptlar için aynı formatı kullanın]

---

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar
1. [Alan 1]
2. [Alan 2]
3. [Alan 3]

### LLM'in Yetersiz Kaldığı Alanlar
1. [Alan 1 - neden yetersiz kaldığı]
2. [Alan 2]

### LLM Kullanımı Hakkında Düşüncelerim
> [Bu case boyunca LLM kullanarak neler öğrendiniz?
> LLM'siz ne kadar sürede bitirebilirdiniz?
> Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
