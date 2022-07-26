#pragma once

#include "Class.g.h"

namespace winrt::ChartDraw_FlexComponents::implementation
{
    struct Class : ClassT<Class>
    {
        Class() = default;

        int32_t MyProperty();
        void MyProperty(int32_t value);
    };
}

namespace winrt::ChartDraw_FlexComponents::factory_implementation
{
    struct Class : ClassT<Class, implementation::Class>
    {
    };
}
