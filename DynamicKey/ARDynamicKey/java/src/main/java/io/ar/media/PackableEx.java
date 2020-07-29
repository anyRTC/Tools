package io.ar.media;

public interface PackableEx extends Packable {
    void unmarshal(ByteBuf in);
}
