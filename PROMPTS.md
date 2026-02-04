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

## Prompt 1: Detecting Multiple Colliders in Range

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

## Prompt 2: C# Script Refactoring to Ludu Arts Standards

**Araç:** Gemini
**Tarih/Saat:** 2026-02-04 02:08

**Prompt:**
```
Birkaç döküman vereceğim ve hepsini inceledikten sonra Ludu Arts C# conventionlarına göre sana atacağım scripti refactor et

Private field'lar için m_ prefix'i kullanın

Private static field'lar için s_ prefix'i kullanın

Private const'lar için k_ prefix'i kullanın

Region'lar standart sırayla kullanılmalı, eklemeyi unutma

Public API'ler XML documentation içermeli

Silent bypass yapılmamalı (hatalar loglanmalı)

[script en son kısımda atıldı ]
```

**Alınan Cevap (Özet):**
```
Yapılan Değişiklikler:

İsimlendirme: m_currentInteractableList gibi camelCase olan private field'lar, PascalCase formatına (m_CurrentInteractableList) dönüştürüldü (Ludu Arts m_ + PascalCase kuralı).

Region Yapısı: Kod; Fields, Unity Methods ve Methods region'larına bölündü.

XML Documentation: Public class için zorunlu olan XML dokümantasyonu eklendi.

Güvenlik: TryGetComponent kullanımı ile optimizasyon sağlandı ve null check'ler güçlendirildi.

Format: Allman style (süslü parantez alt satırda) uygulandı...

[gösterdiği script]
```

**Nasıl Kullandım:**
- [X] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Gözden kaçmış, unuttuğum yanlış yazılmış olanları ludu arts standartlarına göre scripti yapay zekaya refactor ettirdim. Yaklaşık 50 dakikam kaldığından birkaç scriptime de ek olarak aynı promptu uygulayacağım. Neredeyse çoğu scripte uygulamaya çalıştım. Son scriptleri refactor ederken yaklaşık 2-3 dakikam kaldığından daha fazla göz atıp değişikliğe vs. gidemedim.]

Prompt3-4-5-6 vb yukarıdaki 2. prompt ile benzer olacağından böyle bir açıklama yapma gereği duydum. Onun dışında yapay zekaya çok başvurduğumu söyeleyemem. Case study'i yapabilecek düzeyde olduğumu düşünüyordum ancak dökümantasyonlara ve case study'i iyice inceledikten sonra çok süre kaybettiğimi farkettim. Yapay zekaya da chest, switch interaction sistemleri yazdırmak istemedim açıkçası, copy-paste yapmak istemediğimden başvurmadım.

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

*Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır.*
